using System;

namespace pattern_template_method
{
    public class AuditTrail
    {
        public void Record()
        {
            Console.WriteLine("Start logging transaction");
        }

        public void Stop()
        {
            Console.WriteLine("Stop logging transaction");
        }
    }
}