using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decorator_pattern
{
    public class EncryptAndCompressCloudStream : CloudStream
    {
        public override void Write(string data)
        {
            var encrypted = Encrypt(data);
            var compressed = Compress(encrypted);
            base.Write(compressed);
        }
        private string Encrypt(string data) {
            return "#@#$A%@A#SDD";
        }
        private string Compress(string data) {
            return data.Substring(0,5);
        }

        // เขียนโค้ดซ้ำซ้อน โค้ดเดิม หลายไฟล์
    }
}