using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatswordsTab.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ", args));
            Thread.Sleep(1000000);
        }
        
    }
}
