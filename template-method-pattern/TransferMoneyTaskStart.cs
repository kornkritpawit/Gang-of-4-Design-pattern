// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using pattern_template_method;

// namespace template_method_pattern
// {
//     public class TransferMoneyTask
//     {
//         private readonly AuditTrail _auditTrail;
//         public TransferMoneyTask(AuditTrail auditTrail) {
//             _auditTrail = auditTrail;
//         }
//         public void Execute() {
//             _auditTrail.Record();
//             Console.WriteLine("Transfer money");
//             _auditTrail.Stop();
//         }
//     }
// }