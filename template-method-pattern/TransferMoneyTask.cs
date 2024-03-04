using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_template_method;

namespace template_method_pattern
{
    public class TransferMoneyTask : TemplateMethod
    {

        public TransferMoneyTask() : base()
        {
        }

        public TransferMoneyTask(AuditTrail auditTrail) : base(auditTrail)
        {
            
        }
        protected override void DoExecute() //protected จะใช้ได้เฉพาะ ใน template method
        {
            Console.WriteLine("Transfer money");
        }

    }
}