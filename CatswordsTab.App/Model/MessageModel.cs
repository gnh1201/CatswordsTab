using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.App.Model
{
    class MessageModel
    {
        public int Id { get; set; }
        public string Message  { get; set; }
        public string ReplyEmail { get; set; }
        public string HashMD5 { get; set; }
        public string HashSHA1 { get; set; }
        public string HashCRC32 { get; set; }
        public string HashHEAD32 { get; set; }
        public string HashSHA256 { get; set; }
        public string InfoHash { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
