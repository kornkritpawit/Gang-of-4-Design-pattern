using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bridge_pattern
{
    public class SamsungBrand : Device
    {
        // ในงานจริงก็เขียน ไดรเวอร์ของซัมซุง
        public void SetChannel(int number)
        {
            System.Console.WriteLine("Samsung : Set channel to " + number);
        }
        public void TurnOff()
        {
            System.Console.WriteLine("Samsung : Turn off");
        }
        public void TurnOn()
        {
            System.Console.WriteLine("Samsung : Turn on");
        }
    }
}