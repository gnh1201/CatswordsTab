using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using CatswordsTab.Server.Winform;

namespace CatswordsTab.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...!");
            using (var server = new ResponseSocket("@tcp://localhost:26112")) // bind
            {
                while(true)
                {
                    // Receive the message from the server socket
                    string received = server.ReceiveFrameString();
                    Console.WriteLine("Received: {0}", received);

                    // Send a response back from the server
                    server.SendFrame(GetResponseString(received));

                    Thread.Sleep(30);
                }
            }
        }

        static string GetResponseString(string message)
        {
            string response = "Received";

            switch(message)
            {
                case "CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd":
                    Writer writerForm = new Writer();
                    writerForm.Show();
                    break;
            }
            
            return response;
        }
    }
}
