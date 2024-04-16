using System;
using facade_pattern;

namespace pattern_facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new Message("this is sending message");
            var server = new NotificationServer();
            var connection = server.Connection("ip");
            var authToken = server.Authenticate("appId", "key");
            server.Send(authToken, message, "target");
            connection.Disconnect();
            // ปัญหาของแบบข้างบน ใน main คือ โค้ดข้างบนมีความเยอะมาก ต้องสร้างหลาย Object
            // ทำหลายอย่าง
        }
    }
}