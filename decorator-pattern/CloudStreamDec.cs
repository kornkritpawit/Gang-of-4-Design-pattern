using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decorator_pattern
{
    public class CloudStream : Stream
    {
        public void Write(string data) { //virtual คือให้ subclass Override ได้
            System.Console.WriteLine("Storing " + data);
        }
    }
}