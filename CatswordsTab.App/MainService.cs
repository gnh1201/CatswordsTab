using CatswordsTab.App.Model;
using LiteDB;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatswordsTab.App
{
    class MainService
    {
        private static ComputationModel _computed;
        private static string _result = "";

        public static void WriteLine(string text = "")
        {
            _result += text + "\r\n";
        }

        public static string GetResult(string _path)
        {
            _result = "";
            _computed = ComputeService.Compute(_path);

            RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("hash_md5", _computed.MD5);
            request.AddParameter("hash_sha1", _computed.SHA1);
            request.AddParameter("hash_crc32", _computed.CRC32);
            request.AddParameter("hash_sha256", _computed.SHA256);
            request.AddParameter("extension", _computed.Extension);
            request.AddParameter("infohash", _computed.InfoHash);
            request.AddParameter("locale", _computed.SystemLocale);

            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                WriteLine(response.Content);
            }
            else
            {
                WriteLine("# CatswordsTab Report (Offline)");
                WriteLine();
                WriteLine("- MD5: " + _computed.MD5);
                WriteLine("- SHA1: " + _computed.SHA1);
                WriteLine("- CRC32: " + _computed.CRC32);
                WriteLine();
                WriteLine(T._("Please check your internet connection"));
                WriteLine();
                WriteLine("# Comments (Offline)");
                using (LiteDatabase db = new LiteDatabase(AppDataService.GetFilePath("CatswordsTab.App.Data.db")))
                {
                    LiteCollection<MessageModel> messages = db.GetCollection<MessageModel>("messages");
                    IEnumerable<MessageModel> results = messages.Find(x => x.HashMD5.Equals(_computed.MD5));
                    messages.EnsureIndex(x => x.HashMD5);
                    foreach (MessageModel entry in results)
                    {
                        WriteLine("- " + entry.Message + " @" + entry.CreatedOn.ToString());
                    }
                }
            }

            return _result;
        }
    }
}
