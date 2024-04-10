using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace composite_pattern
{
    public class Shape : Component
    {
        public void Move()
        {
            System.Console.WriteLine("Moving Shape");
        }
        public void Render()
        {
            System.Console.WriteLine("Render Shape");
        }
    }
}