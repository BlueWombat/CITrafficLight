using CITrafficLight.Shared;

namespace CITrafficLight
{
    class RelayControl
    {
        public static void SetRelays(Enums.LampColors lampColors)
        {
            switch (lampColors)
            {
                case Enums.LampColors.Red:
                    // TODO Add Red light logic
                    return;
                case Enums.LampColors.Yellow:
                    // TODO Add Yellow light logic
                    return;
                case Enums.LampColors.Green:
                    // TODO Add Green light logic
                    return;
            }
        }
    }
}
