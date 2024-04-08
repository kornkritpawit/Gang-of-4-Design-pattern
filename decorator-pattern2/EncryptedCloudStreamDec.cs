namespace decorator_pattern
{
    public class EncryptedCloudStreamDec : Stream
    {
        private Stream _stream;

        public EncryptedCloudStreamDec(Stream stream)
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