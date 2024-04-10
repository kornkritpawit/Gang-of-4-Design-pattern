using bridge_pattern;

namespace pattern_bridge
{
    public class AdvancedRemoteControlB : RemoteControlB
    {
        public AdvancedRemoteControlB(Device device) : base(device)
        {
        }

        public void SetChannel(int number) {
            device.SetChannel(number);
        }
    }
}