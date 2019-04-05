using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.Server
{
    class ResponseBase
    {
        private readonly string EOL = "\r\n";

        protected string _eol(string str)
        {
            return str + EOL;
        }
    }
}
