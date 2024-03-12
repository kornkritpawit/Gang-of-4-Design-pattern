# Decorator Pattern Conclude
- Starter project: https://github.com/utarn/csharp-pattern-decorator/tree/d61785d6ccec4b0a09fe111de0d676377feabaf0
- Finish project: https://github.com/utarn/csharp-pattern-decorator/tree/d1eff2f0b6c8943e351bf312a7a1d7e94f2bb5b1
# Decorator Pattern Conclude
ออกแบบมาเพื่อให้สามารถเพิ่มคุณสมบัติหรือความสามารถให้กับวัตถุ ได้อย่างอิสระโดยที่ไม่กระทบกับการทำงานเดิมของคลาสอื่นที่เรียกใช้วัตถุนี้ ยกตัวอย่างเช่น เราเขียนคลาสสำหรับอัพโหลดข้อมูลขึ้นไปไว้บนคลาวด์ เมื่อเวลาผ่านไปความต้องการของระบบเปลี่ยน โดยต้องการให้มีการเข้ารหัส หรือบีบอัดข้อมูล เรายังคงสามารถเพิ่มคุณสมบัติดังกล่าวโดยที่ไม่ต้องแก้ไขคลาสอื่นที่เดิมเรียกใช้วัตถุนี้ตอนที่ยังไม่ได้เพิ่มคุณสมบัติใหม่เข้าไป

Design1: 
- class CloudStream: pub virtual void Write(string data){Sys.cwl("Storing"+data);}//virtualว้ให้subclassมา override
- class CompressCloudStream inherit CloudStream: pub override void Write(string data){
	var compressed=Compress(data); base.Write(compressed);}
	- pri string Compress(string data) {return data.Substring(0,5);}
- class EncryptedCloudStream inherit CLoudStream: pub override void Write(){
	var encrypte = Encrypt(data); base.Write(encrypted);}
	- pri string Encrypt(string data) {return "#@#$A%@A#SDD";}
- class EncryptAndCompressCloudStream inherit CloudStream: pub override void Write(string data){
	var encrypted=Encrypt(data); var compressed=Compress(encrypted); base,Write(compressed);}
	- pri string Encrypt(string data){return "#@#$A%@A#SDD";}
	- pri string Compress(string data){return data.Substring(0,5);}
ตัวอย่างใน Program.cs
```
			var data = "This is uploading data.";
            var cloudStream1 = new CloudStream();
            var cloudStream2 = new EncryptedCloudStream();
            var cloudStream3 = new CompressCloudStream();
            var cloudStream4 = new EncryptAndCompressCloudStream();
			cloudStream1.Write(data);cloudStream2.Write(data);
			cloudStream3.Write(data);cloudStream4.Write(data);
Output:
Storing This is uploading data.
Storing #@#$A%@A#SDD
Storing This 
Storing #@#$A
```
- ข้อเสียของแบบแรกคือ EncryptAndCompressCloudStream มีการใช้โค้ดซ้ำและ ถ้ามีฟีเจอร์ใหม่ก็ต้องเพิ่ม class และมีการทำ Inheritance
ที่เยอะและวุ่นวายไปหมด

Design 2:
- สร้าง Interface Stream: void Write(string data)
- class CloudStream implement interface Stream: pub void Write(Sys.cwl("Storing "+data);)
- class CompressCloudStream implement Stream: pri Stream _stream;
	- Constructor(Stream stream){_stream=stream;}
	- pub void Write(str data){var compressed = Compress(data); _stream.Write(compressed);}
	- pri str Compress(str data) {return data.Substring(0,5)}
- class EncryptedCloudStream implement Stream: pri Stream _stream;
	- Constructor(Stream stream){_stream=stream;}
	- pub void Write(str data) {var encrypted=Encrypt(data); _stream.Write(encrypte);}
	- pri str Encrypt(str data) {return "#@#$A%@A#SDD"}
- เพิ่ม static void WriteCreditCard(Stream stream) ใน Program.cs {
    stream.Write("1234-1234-1234-1234");}
ตัวอย่างใน Program.cs
```
            var cloudStream = new CloudStreamDec();
            var compressStream = new CompressCloudStreamDec(cloudStream); //สั่งCompressก่อนแล้วสั่งcloudstream.Write
            var encryptedStream = new EncryptedCloudStreamDec(cloudStream);
            var compressAndEncrypt = new CompressCloudStreamDec(encryptedStream);
            var encryptedAndCompress = new EncryptedCloudStreamDec(compressStream);
            cloudStream.Write(data); compressStream.Write(data);
            encryptedStream.Write(data); compressAndEncrypt.Write(data);
            encryptedAndCompress.Write(data); WriteCreditCard(encryptedAndCompress);
            WriteCreditCard(compressStream);
Output:
Storing This is uploading data.
Storing This 
Storing #@#$A%@A#SDD
Storing #@#$A%@A#SDD
Storing #@#$A
Storing #@#$A
Storing 1234-
```
- สร้าง Class implement Stream มี Constructor แล้วก็ เพิ่มคุณสมบัติเข้าไป
ใช้หลักการ Composition เราสาามารถ เพิ่มคุณสมบัติ เข้าไปเพิ่มสลับคุณสมบัติได้ตามที่ต้องการ