namespace decorator_pattern
{
    public class EncryptedCloudStream : Stream
    {
        private Stream _stream;
        public EncryptedCloudStream(Stream stream)
        {
            _stream = stream;
        }
        public void Write(string data)
        {
            var encrypted = Encrypt(data);
            _stream.Write(encrypted);
        }
        private string Encrypt(string data) {
            return "#@#$A%@A#SDD";
        }
    }
}