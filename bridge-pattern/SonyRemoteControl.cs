namespace pattern_bridge
{
    public class SonyRemoteControl : RemoteControl
    {
        public override void TurnOff()
        {
            System.Console.WriteLine("Sony : Turn off");
        }

        public override void TurnOn()
        {
            System.Console.WriteLine("Sony : Turn on");
        }
    }
}