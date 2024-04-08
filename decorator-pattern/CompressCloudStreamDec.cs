using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace decorator_pattern
{
    public class CompressCloudStream:  Stream
    {
        private Stream _stream;
        public CompressCloudStream(Stream stream)
        {
            _stream = stream;
        }
        public void Write(string data)
        {
            var compressed = Compress(data);
            _stream.Write(compressed);
        }
        private string Compress(string data) {
            return data.Substring(0,5);
        }
    }
}