using decorator_pattern;
using Stream = decorator_pattern.Stream;

namespace pattern_decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = "This is uploading data.";
            // var cloudStream = new CloudStream();
            // var cloudStream = new EncryptedCloudStream();
            // var cloudStream = new CompressCloudStream();
            // var cloudStream = new EncryptAndCompressCloudStream();
            // class เยอะแยะไปหมด ถ้าทำ แบบ Inheritance

            var cloudStream = new CloudStreamDec();
            var compressStream = new CompressCloudStreamDec(cloudStream); //สั่ง Compress ก่อนแล้วสั่ง cloudstream.Write
            var encryptedStream = new EncryptedCloudStreamDec(cloudStream);
            var compressAndEncrypt = new CompressCloudStreamDec(encryptedStream);
            var encryptedAndCompress = new EncryptedCloudStreamDec(compressStream);

            // cloudStream.Write(data);
            // compressStream.Write(data);
            // encryptedStream.Write(data);
            // compressAndEncrypt.Write(data);
            // encryptedAndCompress.Write(data);

            // WriteCreditCard(encryptedAndCompress);
            WriteCreditCard(compressStream);
            //ก็คือ สร้าง Class implement Stream มี constructor แล้วก็เพิ่มคุณสมบัติเข้าไป
            //เพิ่มลบ สลับลำดับได้ตามต้องการ
        }
        static void WriteCreditCard(Stream stream) {
            stream.Write("1234-1234-1234-1234");
        }
    }
}

