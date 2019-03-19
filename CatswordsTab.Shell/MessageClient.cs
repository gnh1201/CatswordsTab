using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CatswordsTab.Shell
{
    static class MessageClient
    {
        private static Queue<string> TxQueue;
        private static Queue<string> RxQueue;

        static MessageClient() {
            TxQueue = new Queue<string>();
            RxQueue = new Queue<string>();
        }

        public static void Push(string message)
        {
            TxQueue.Enqueue(message);
        }

        public static string Pull()
        {
            string message = null;
            while (RxQueue.Count > 0)
            {
                if (message == null)
                {
                    message = "";
                }
                message += RxQueue.Dequeue();
            }
            return message;
        }

        public static void Commit() {
            using (var client = new RequestSocket(">tcp://localhost:26112"))  // connect
            {
                try
                {
                    while (TxQueue.Count > 0)
                    {
                        string message = TxQueue.Dequeue();
                        client.SendFrame(message);

                        string received = client.ReceiveFrameString();
                        RxQueue.Enqueue(received);
                    }
                }
                catch (Exception e)
                {
                    Push("Exception");
                    Push(e.StackTrace);
                }
            }
        }

        public static string GetLocale()
        {
            string locale = "en";
            string culture = CultureInfo.CurrentUICulture.Name;
            string[] terms = culture.Split('-');

            if (terms.Length > 0)
            {
                locale = terms[0];
            }

            return locale;
        }
    }
}
