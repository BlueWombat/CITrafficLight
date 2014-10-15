namespace CITrafficLight.Shared
{
    public interface ICIServer
    {
        Enums.LampColors GetLampColor(string scheme, string host, int port, string username, string password);
    }
}