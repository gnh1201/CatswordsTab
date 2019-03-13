using NetMQ;
using NetMQ.Sockets;
using System;
using System.Threading;

namespace CatswordsTab.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...!");
            using (var client = new RequestSocket(">tcp://localhost:26112"))  // connect
            {
                while(true) {
                    // Send a message from the client socket
                    client.SendFrame(GetRandomString());

                    // Receive the response from the client socket
                    string m2 = client.ReceiveFrameString();
                    Console.WriteLine("From Server: {0}", m2);

                    Thread.Sleep(30);
                }
            }
        }

        static string GetRandomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[16];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new string(stringChars);

            return finalString;
        }
    }
}
