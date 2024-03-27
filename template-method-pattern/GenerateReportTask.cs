using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace template_method_pattern
{
    public class GenerateReportTask : TemplateMethod
    {
        public GenerateReportTask()
        {
        }
        protected override void DoExecute()
        {
            Console.WriteLine("Generate Report");
        }
    }
}