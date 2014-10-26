using System;
using System.Threading;
using CITrafficLight.Shared;

namespace CITrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var lastLampColor = Enums.LampColors.Red;
            var ciServer = PluginLoader.InitCiServer(Settings.CIServer);
            var lampController = PluginLoader.InitLampController(Settings.LampController);
            var timer = new Timer(state =>
            {
                var lampColor = ciServer.GetLampColor(Settings.Scheme, Settings.Host, Settings.Port.Value, Settings.Username, Settings.Password);
                if (lampColor != lastLampColor)
                    lampController.SetLampColor(lampColor);
                lastLampColor = lampColor;
                Console.WriteLine(lampColor);
            }, null, 0, Settings.UpdateInterval.Value);
            while (true)
            {
            }
        }
    }
}
