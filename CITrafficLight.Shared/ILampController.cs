using CITrafficLight.Shared;

namespace CITrafficLight
{
    public interface ILampController
    {
        void SetLampColor(Enums.LampColors lampColors);

        void TurnOff();
    }
}