using bridge_pattern;

namespace pattern_bridge
{
    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(Device device) : base(device)
        {
        }

        public void SetChannel(int number) {
            device.SetChannel(number);
        }
    }
}