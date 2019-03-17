using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CatswordsTab.Server.Model;

namespace CatswordsTab.Server
{
    class Communicate : ResponseBase
    {
        private static string AuthType = "bearer";
        private static string AuthToken = string.Empty;
        private static string BaseUri = "https://catswords.re.kr";

        public static void DoLogin(string username, string password)
        {
            JObject JsonData = new JObject
            {
                { "email", username },
                { "password", password }
            };
            string response = RequestPost("/_/auth/authenticate", JsonData.ToString());
            SetAuthToken(response);
        }

        // alternative to RestSharp
        // http://www.csharpstudy.com/web/article/16-HttpWebRequest-%ED%99%9C%EC%9A%A9
        public static string RequestGet(string uri)
        {
            string responseText = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUri + uri);
            request.Method = "GET";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab/2.0 (https://catswords.com)";
            if (!GetAuthToken().Equals(string.Empty))
            {
                request.Headers.Add("Authorization", GetAuthorization());
            }

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }

            return responseText;
        }

        public static string RequestPost(string uri, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUri + uri);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab/2.0 (https://catswords.com)";
            if (!GetAuthToken().Equals(string.Empty))
            {
                request.Headers.Add("Authorization", GetAuthorization());
            }

            // write stream data
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            request.ContentLength = bytes.Length; // set number of bytes
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }

            // Response 처리
            string responseText = string.Empty;
            using (WebResponse resp = request.GetResponse())
            {
                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }

            return responseText;
        }

        public static void SetAuthToken(string json)
        {
            var response = JsonConvert.DeserializeObject<AuthResponse>(json);
            AuthToken = response.Data.Token;
        }

        public static string GetAuthToken()
        {
            return AuthToken;
        }

        public static string GetAuthorization()
        {
            return AuthType + " " + GetAuthToken();
        }

    }
}
