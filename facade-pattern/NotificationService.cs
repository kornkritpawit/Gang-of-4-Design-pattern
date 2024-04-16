using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pattern_facade;

namespace facade_pattern
{
    public class NotificationService
    {
        public void Send(string message, string target)
        {
            var server = new NotificationServer();
            var connection = server.Connection("ip");
            var authToken = server.Authenticate("appId", "key");
            server.Send(authToken, new Message(message), "target");
            connection.Disconnect();
        }
    }
}