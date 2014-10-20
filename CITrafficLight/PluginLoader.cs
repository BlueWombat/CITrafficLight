using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CITrafficLight.Shared;

namespace CITrafficLight
{
    static class PluginLoader
    {
        public static ICIServer InitCiServer()
        {
            return InitPlugin("ICIServer") as ICIServer;
        }

        private static object InitPlugin(string interfaceName)
        {
            var assemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            var pluginfolder = new DirectoryInfo(assemblyPath);
            if (!pluginfolder.Exists)
                throw new ApplicationException("No plugins present");
            Type ciServerType = null;
            foreach (var fileInfo in pluginfolder.GetFiles("*.dll"))
            {
                ciServerType = Assembly.LoadFrom(fileInfo.FullName).ExportedTypes.FirstOrDefault(t => t.GetInterface(interfaceName) != null);
                if (ciServerType.Name == Settings.CIServer)
                    break;
            }
            var ciServerConstructor = ciServerType.GetConstructor(new Type[] { });
            var ciServer = ciServerConstructor.Invoke(new object[] { });
            return ciServer;
        }
    }
}
