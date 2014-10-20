using System.Configuration;

namespace CITrafficLight
{
    static class Settings
    {
        private static string _CIServer;
        private static string _Scheme;
        private static string _Host;
        private static int? _Port;
        private static string _Username;
        private static string _Password;

        private static int? _UpdateInterval;

        public static string CIServer { get { return _CIServer ?? (_CIServer = ConfigurationManager.AppSettings["ci_server"]); } }
        public static string Scheme { get { return _Scheme ?? (_Scheme = ConfigurationManager.AppSettings["scheme"]); } }
        public static string Host { get { return _Host ?? (_Host = ConfigurationManager.AppSettings["host"]); } }
        public static int? Port { get { return _Port ?? (_Port = int.Parse(ConfigurationManager.AppSettings["port"])); } }
        public static string Username { get { return _Username ?? (_Username = ConfigurationManager.AppSettings["username"]); } }
        public static string Password { get { return _Password ?? (_Password = ConfigurationManager.AppSettings["password"]); } }

        public static int? UpdateInterval { get { return _UpdateInterval ?? (_UpdateInterval = int.Parse(ConfigurationManager.AppSettings["update_interval"])); } }
    }
}
