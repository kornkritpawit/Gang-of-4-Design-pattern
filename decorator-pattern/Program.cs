using decorator_pattern;
using Stream = decorator_pattern.Stream;

namespace pattern_decorator
{
    class Program
    {
        // static void Main(string[] args)
        // {
        //     var data = "This is uploading data.";
        //     var cloudStream1 = new CloudStream();
        //     var cloudStream2 = new EncryptedCloudStream();
        //     var cloudStream3 = new CompressCloudStream();
        //     var cloudStream4 = new EncryptAndCompressCloudStream();
        //     cloudStream1.Write(data);cloudStream2.Write(data);
        //     cloudStream3.Write(data);cloudStream4.Write(data);
        // }

        // static void Main(string[] args)
        // {
        //     var data = "This is uploading data.";

        //     var cloudStream = new CloudStream();
        //     var compressStream = new CompressCloudStream(cloudStream); //สั่ง Compress ก่อนแล้วสั่ง cloudstream.Write
        //     var encryptedStream = new EncryptedCloudStream(cloudStream);
        //     var compressAndEncrypt = new CompressCloudStream(encryptedStream);
        //     var encryptedAndCompress = new EncryptedCloudStream(compressStream);

        //     cloudStream.Write(data);
        //     compressStream.Write(data);
        //     encryptedStream.Write(data);
        //     compressAndEncrypt.Write(data);
        //     encryptedAndCompress.Write(data);
        // }

        static void Main(string[] args)
        {
            var data = "This is uploading data.";

            var cloudStream = new CloudStream();
            var compressStream = new CompressCloudStream(cloudStream); //สั่ง Compress ก่อนแล้วสั่ง cloudstream.Write
            var encryptedAndCompress = new EncryptedCloudStream(compressStream);
            WriteCreditCard(encryptedAndCompress);
            WriteCreditCard(compressStream);
            //ก็คือ สร้าง Class implement Stream มี constructor แล้วก็เพิ่มคุณสมบัติเข้าไป
            //เพิ่มลบ สลับลำดับได้ตามต้องการ
        }
        
        static void WriteCreditCard(Stream stream) {
            stream.Write("1234-1234-1234-1234");
        }
    }
}

