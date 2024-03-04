using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_template_method;

namespace template_method_pattern
{
    public abstract class TemplateMethod
    {
        private readonly AuditTrail _auditTrail;

        public TemplateMethod()
        {
            _auditTrail = new AuditTrail();
        }

        public TemplateMethod(AuditTrail auditTrail)
        {
            _auditTrail = auditTrail;
        }

        public void Execute() {
            _auditTrail.Record();
            DoExecute();
            _auditTrail.Stop();
        }

        protected abstract void DoExecute();
    }
}