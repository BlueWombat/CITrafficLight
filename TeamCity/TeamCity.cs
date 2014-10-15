using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using CITrafficLight.Shared;

namespace TeamCity
{
    public class TeamCity : ICIServer
    {
        public Enums.LampColors GetLampColor(string scheme, string host, int port, string username, string password)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format("{0}://{1}:{2}/httpAuth/app/rest/builds?locator=running%3Aany%2Ccanceled%3Afalse", scheme, host, port));
            request.Credentials = new NetworkCredential(username, password);
            var response = (HttpWebResponse)request.GetResponse();
            var respStream = response.GetResponseStream();
            var buffer = new List<byte>();
            int b = 0;
            while ((b = respStream.ReadByte()) > -1)
            {
                buffer.Add((byte)b);
            }
            string xml = Encoding.UTF8.GetString(buffer.ToArray());
            var xdoc = XDocument.Parse(xml);
            var items = xdoc.Element("builds").Elements("build");
            items = items.GroupBy(e => e.Attribute("buildTypeId").Value, e => e).Select(e => e.First());
            var lampColor = Enums.LampColors.Green;
            foreach (var item in items)
            {
                string status = item.Attribute("status").Value, state = item.Attribute("state").Value;
                if (state.ToLowerInvariant() == "running")
                    lampColor = Enums.LampColors.Yellow;
                else if (status.ToLowerInvariant() == "success" && lampColor != Enums.LampColors.Yellow && lampColor != Enums.LampColors.Red)
                    lampColor = Enums.LampColors.Green;
                else
                    lampColor = Enums.LampColors.Red;
            }
            return lampColor;
        }
    }
}
