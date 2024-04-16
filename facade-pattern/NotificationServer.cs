using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using pattern_facade;

namespace facade_pattern
{
    public class NotificationServer
    {   
        // real Precess
        // connect --> Connection
        // authenticate --> (appId, key) --> AuthToken
        // send --> (authToken, message, target)
        // disconnect
        public Connection Connection(string ipAddress) {
            return new Connection();
        }
        public AuthToken Authenticate(string appId, string key) {
            return new AuthToken();
        }
        public void Send(AuthToken authToken, Message message, string target) {
            System.Console.WriteLine("Sending a message.");
        }
    }
}