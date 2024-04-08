namespace decorator_pattern
{
    public class EncryptedCloudStream : CloudStream
    {
        public override void Write(string data)
        {
            var encrypted = Encrypt(data);
            base.Write(encrypted);
        }

        private string Encrypt(string data) {
            return "#@#$A%@A#SDD";
        }
    }
}