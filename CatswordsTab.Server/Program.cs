using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace CatswordsTab.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new ResponseSocket("@tcp://localhost:26112")) // bind
            {
                while(true)
                {
                    // Receive the message from the server socket
                    string m1 = server.ReceiveFrameString();
                    Console.WriteLine("From Client: {0}", m1);
                }
            }
        }
    }
}
