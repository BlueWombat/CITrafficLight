using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using CITrafficLight.Shared;

namespace CITrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            var pluginfolder = new DirectoryInfo(assemblyPath);
            if (!pluginfolder.Exists)
                throw new ApplicationException("No plugins present");
            Type ciServerType = null;
            foreach (var fileInfo in pluginfolder.GetFiles("*.dll"))
            {
                ciServerType = Assembly.LoadFrom(fileInfo.FullName).ExportedTypes.FirstOrDefault(t => t.GetInterface("ICIServer") != null);
                if (ciServerType.Name != Settings.CIServer)
                    continue;
                if (ciServerType != null)
                    break;
            }
            var ciServerConstructor = ciServerType.GetConstructor(new Type[] { });
            var ciServer = ciServerConstructor.Invoke(new object[] { }) as ICIServer;
            var timer = new Timer(state =>
            {
                var lampColor = ciServer.GetLampColor(Settings.Scheme, Settings.Host, Settings.Port, Settings.Username, Settings.Password);
                RelayControl.SetRelays(lampColor);
                Console.WriteLine(lampColor);
            }, null, 0, Settings.UpdateInterval);
            while (true)
            {
            }
        }
    }
}
