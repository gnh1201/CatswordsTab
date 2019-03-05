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
        private string ResponseText = "";

        public void AppandResponseText(string text, bool newline = true)
        {
            ResponseText += text;
            if (newline == true)
            {
                ResponseText += EOL;
            }
        }

        public string GetResponseText()
        {
            return ResponseText;
        }
    }
}
