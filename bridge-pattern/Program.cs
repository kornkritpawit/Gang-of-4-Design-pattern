using System;
using bridge_pattern;

namespace pattern_bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var SonyRemoteControl = new RemoteControl(new SonyBrand());
            var SamsungRemoteControl = new RemoteControl(new SamsungBrand());
            var SamsungAdvanceRemoteControl = new AdvancedRemoteControl(new SamsungBrand());
            var SonyAdvanceRemoteControl = new AdvancedRemoteControl(new SonyBrand());
            SonyRemoteControl.TurnOn();
            SamsungRemoteControl.TurnOn();
            SamsungAdvanceRemoteControl.TurnOn();
            SonyAdvanceRemoteControl.TurnOn();
            SamsungAdvanceRemoteControl.SetChannel(5);
            SonyAdvanceRemoteControl.SetChannel(5);
            // มี 2 สายของการพัฒนา อันนึงอาจจะเป็น implementation ใช้กับประเภทอะไร Datastorage แบบไหน หรือเครือข่ายอะไร หรือว่า provider คนละแบบ
            // อีกอันนึงจะเป็นเรื่อง ของ feature ว่าเราจะ ใส่คุณสมบัติอะไรเพิ่ม เหมือนแบบ Remote control
        }
    }
}