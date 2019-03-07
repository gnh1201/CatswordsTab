using NetMQ;
using NetMQ.Sockets;
using System;

namespace CatswordsTab.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new RequestSocket(">tcp://localhost:26112"))  // connect
            {
                while(true) {
                    // Send a message from the client socket
                    client.SendFrame("Hello");
                }
            }
        }
    }
}
