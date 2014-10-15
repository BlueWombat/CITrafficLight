using System.Configuration;

namespace CITrafficLight
{
    static class Settings
    {
        public static string CIServer { get { return ConfigurationManager.AppSettings["ci_server"]; } }
        public static string Scheme { get { return ConfigurationManager.AppSettings["scheme"]; } }
        public static string Host { get { return ConfigurationManager.AppSettings["host"]; } }
        public static int Port { get { return int.Parse(ConfigurationManager.AppSettings["port"]); } }
        public static string Username { get { return ConfigurationManager.AppSettings["username"]; } }
        public static string Password { get { return ConfigurationManager.AppSettings["password"]; } }
        public static int UpdateInterval { get { return int.Parse(ConfigurationManager.AppSettings["update_interval"]); } }
    }
}
