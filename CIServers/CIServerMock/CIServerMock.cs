using System;
using CITrafficLight.Shared;

namespace CIServerMock
{
    public class Mock : ICIServer
    {
        public Enums.LampColors GetLampColor(string scheme, string host, int port, string username, string password)
        {
            var rand = new Random().Next(1, 4);
            switch (rand)
            {
                default:
                    return Enums.LampColors.Red;
                case 2:
                    return Enums.LampColors.Yellow;
                case 3:
                    return Enums.LampColors.Green;
            }
        }
    }
}
