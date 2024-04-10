using bridge_pattern;

namespace pattern_bridge
{
   // RemoteControl
      // AdvanceRemoteControl
      // MovieRemoteControl
   public class RemoteControlB
   {
      protected Device device;

        public RemoteControlB(Device device)
        {
            this.device = device;
        }
        public void TurnOn() {
         device.TurnOn();
        }
        public void TurnOff() {
         device.TurnOff();
        }
    }
} 