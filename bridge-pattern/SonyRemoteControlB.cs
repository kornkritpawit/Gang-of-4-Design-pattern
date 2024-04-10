using bridge_pattern;

namespace pattern_bridge
{
    public class SonyBrand : Device
    {
        public void SetChannel(int number)
        {
            System.Console.WriteLine("Sony : Set channel to " + number);
        }
        public void TurnOff()
        {
            System.Console.WriteLine("Sony : Turn off");
        }
        public void TurnOn()
        {
            System.Console.WriteLine("Sony : Turn on");
        }
    }
}