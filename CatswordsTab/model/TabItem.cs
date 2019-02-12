﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatswordsTab.model
{
    class TabItem
    {
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string Message { get; set; }
        public string HashCrc32 { get; set; }
        public string HashMd5 { get; set; }
        public string HashSha1 { get; set; }
        public string HashHead32 { get; set; }
        public string Extension { get; set; }

        public string ToJson(bool withHeader = false)
        {
            JObject obj = new JObject();
            if (withHeader == true) {
                obj.Add("id", Id);
                obj.Add("created_by", CreatedBy);
                obj.Add("created_on", CreatedOn);
            }
            obj.Add("message", Message);
            obj.Add("hash_crc32", HashCrc32);
            obj.Add("hash_md5", HashMd5);
            obj.Add("hash_sha1", HashSha1);
            obj.Add("hash_head32", HashHead32);
            obj.Add("extension", Extension);

            return obj.ToString();
        }
    }

}
