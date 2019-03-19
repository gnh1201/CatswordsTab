using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.Server
{
    class MessageService
    {
        private static Queue<string> TxQueue;
        private static Queue<string> RxQueue;

        static MessageService()
        {
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

        public static void Commit()
        {
            while (TxQueue.Count > 0)
            {
                string message = TxQueue.Dequeue();
                RxQueue.Enqueue(message);
            }
        }
    }
}