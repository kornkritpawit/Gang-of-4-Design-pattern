using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bridge_pattern
{
    // Device
        // SonyBrand
        // SamsungBrand
    public interface Device
    {
        void TurnOn();
        void TurnOff();
        void SetChannel(int number);
    }
}

