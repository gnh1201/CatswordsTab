using System;
namespace CatswordsTab.WebApi.Model
{
    public class MessageModel
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
