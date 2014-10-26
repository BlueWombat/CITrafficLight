using CITrafficLight;
using CITrafficLight.Shared;
using FTD2XX_NET;

namespace DenkoviUSB4RelayController
{
    public class DenkoviUSB4RelayController : ILampController
    {
        private readonly FTDI relayController;

        private byte[] sentBytesBuffer;
        private uint recievedBytes;
        private FTDI.FT_STATUS relayControllerStatus;

        public DenkoviUSB4RelayController()
        {
            this.relayController = new FTDI();
            this.sentBytesBuffer = new byte[2];

            this.relayControllerStatus = relayController.OpenByIndex(0);
            this.relayControllerStatus = relayController.SetBaudRate(921600);
            this.relayControllerStatus = relayController.SetBitMode(255, 4);
            this.sentBytesBuffer[0] = 0;
        }

        public void SetLampColor(Enums.LampColors lampColors)
        {
            switch (lampColors)
            {
                case Enums.LampColors.Red:
                    this.TurnOnRed();

                    this.TurnOffYellow();
                    this.TurnOffGreen();
                    return;
                case Enums.LampColors.Yellow:
                    this.TurnOnYellow();

                    this.TurnOffRed();
                    this.TurnOffGreen();
                    return;
                case Enums.LampColors.Green:
                    this.TurnOnGreen();

                    this.TurnOffRed();
                    this.TurnOffYellow();
                    return;
            }
        }

        public void TurnOff()
        {
            this.TurnOffRed();
            this.TurnOffYellow();
            this.TurnOffGreen();
        }

        private void TurnOnGreen()
        {
            // Turn on green
            this.sentBytesBuffer[0] = (byte)(sentBytesBuffer[0] | 32);
            this.relayControllerStatus = this.relayController.Write(this.sentBytesBuffer, 1, ref this.recievedBytes);
        }

        private void TurnOffRed()
        {
            // Turn off red
            this.sentBytesBuffer[0] = (byte)(sentBytesBuffer[0] & 253);
            this.relayControllerStatus = this.relayController.Write(this.sentBytesBuffer, 1, ref this.recievedBytes);
        }

        private void TurnOnYellow()
        {
            // Turn on yellow
            this.sentBytesBuffer[0] = (byte)(sentBytesBuffer[0] | 8);
            this.relayControllerStatus = this.relayController.Write(this.sentBytesBuffer, 1, ref this.recievedBytes);
        }

        private void TurnOnRed()
        {
            // Turn on red
            this.sentBytesBuffer[0] = (byte)(sentBytesBuffer[0] | 2);
            this.relayControllerStatus = this.relayController.Write(this.sentBytesBuffer, 1, ref this.recievedBytes);
        }

        private void TurnOffGreen()
        {
            // Turn off green
            this.sentBytesBuffer[0] = (byte)(sentBytesBuffer[0] & 223);
            this.relayControllerStatus = this.relayController.Write(this.sentBytesBuffer, 1, ref this.recievedBytes);
        }

        private void TurnOffYellow()
        {
            // Turn off yellow
            this.sentBytesBuffer[0] = (byte)(sentBytesBuffer[0] & 247);
            this.relayControllerStatus = this.relayController.Write(this.sentBytesBuffer, 1, ref this.recievedBytes);
        }
    }
    }
}
