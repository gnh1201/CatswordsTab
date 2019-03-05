using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;
using CatswordsTab.Shell.Properties;
using CatswordsTab.Shell.Model;
using System.Globalization;
using Newtonsoft.Json;

namespace CatswordsTab.Shell
{
    public static class Helper
    {
        private static string AuthToken = string.Empty;
        private static PrivateFontCollection pfc = null;
        private static Dictionary<string, string> ConfigTable;
        private static Dictionary<string, string> LocaleTable;
        public static Page TabPage = null;
        public static FormAuth TabAuth = null;
        public static ForrnWriter TabWriter = null;
        public static FormExpert TabExpert = null;
        public static string ReportData = "Please visit us. https://catswords.com";
        public static string EOL = "\r\n";
        
        static Helper()
        {
            InitalizeFontCollection();
            InitalizeLocale();
        }

        private static void InitalizeFontCollection()
        {
            pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.NotoSansCJKkr_Regular.Length;
            byte[] fontdata = Properties.Resources.NotoSansCJKkr_Regular;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
        }

        private static void InitalizeConfig()
        {
            ConfigTable = new Dictionary<string, string>();
            ConfigTable.Add("BASE_URL", "https://2s.re.kr");
            ConfigTable.Add("AUTH_TYPE", "bearer");
            ConfigTable.Add("AUTH_REQUEST_URI", "/_/auth/authenticate");
            ConfigTable.Add("PAGE_REQUEST_URI", "/portal/?route=tab");
            ConfigTable.Add("DEFAULT_USERNAME", "guest.tab@catswords.com");
            ConfigTable.Add("DEFAULT_PASSWORD", "d3nexkz9UkP8ur77");
        }

        // bypass GAC non-compatible (Could not use localization file in GAC mode)
        private static void InitalizeLocale()
        {
            LocaleTable = new Dictionary<string, string>();

            if (GetCurrentLanaguage() == "ko-KR")
            {
                LocaleTable.Add("PAGE_TITLE", "커뮤니티");
                LocaleTable.Add("PAGE_BUTTON_ADD", "의견작성");
                LocaleTable.Add("PAGE_LABEL_TITLE", "커뮤니티");
                LocaleTable.Add("WRITER_BUTTON_SEND", "저장");
                LocaleTable.Add("WRITER_LABEL_MESSAGE", "남기실 말");
                LocaleTable.Add("WRITER_CHECKBOX_AGREEMENT", "개인정보 수집 및 이용 약관에 동의합니다");
                LocaleTable.Add("WRITER_MESSAGE_AGREEMENT", "개인정보 수집 및 이용 약관에 동의하셔야 합니다");
                LocaleTable.Add("WRITER_MESSAGE_SENT", "등록이 완료되었습니다");
                LocaleTable.Add("WRITER_LABEL_TITLE", "의견작성");
                LocaleTable.Add("WRITER_LABEL_REPLAY_EMAIL", "전자우편 (선택, 회신이 필요할 때만 작성)");
                LocaleTable.Add("WRITER_TITLE", "의견작성");
                LocaleTable.Add("AUTH_BUTTON_LOGIN", "로그인");
                LocaleTable.Add("AUTH_LABEL_USERNAME", "사용자 전자우편");
                LocaleTable.Add("AUTH_LABEL_PASSWORD", "사용자 열쇠글");
                LocaleTable.Add("AUTH_LABEL_TITLE", "인증");
                LocaleTable.Add("AUTH_LABEL_COPYRIGHT", "(c) Catswords Community, OSL");
                LocaleTable.Add("AUTH_TITLE", "인증");
                LocaleTable.Add("AUTH_MESSAGE_LOGIN_SUCCEED", "로그인하였습니다");
                LocaleTable.Add("AUTH_MESSAGE_LOGIN_FAILED", "사용자 전자우편 또는 열쇠글을 확인하세요");
                LocaleTable.Add("EXPERT_LABEL_TITLE", "전문가 모드");
                LocaleTable.Add("EXPERT_BUTTON_LOGIN", "로그인");
                LocaleTable.Add("EXPERT_TITLE", "전문가 모드");
                LocaleTable.Add("EXPERT_TABPAGE_QUERY", "쿼리");
                LocaleTable.Add("EXPERT_TAGPAGE_REPORT", "보고서");
                LocaleTable.Add("EXPERT_LABEL_MD5", "MD5");
                LocaleTable.Add("EXPERT_LABEL_SHA1", "SHA1");
                LocaleTable.Add("EXPERT_LABEL_CRC32", "CRC32");
                LocaleTable.Add("EXPERT_LABEL_HEAD32", "HEAD32");
                LocaleTable.Add("EXPERT_LABEL_EXTENSION", "확장자");
                LocaleTable.Add("EXPERT_LABEL_LANGUAGE", "언어");
                LocaleTable.Add("EXPERT_BUTTON_QUERY", "요청하기");
            }
            else
            {
                LocaleTable.Add("PAGE_TITLE", "Community");
                LocaleTable.Add("PAGE_BUTTON_ADD", "Write a comment");
                LocaleTable.Add("PAGE_LABEL_TITLE", "Community");
                LocaleTable.Add("WRITER_BUTTON_SEND", "Send");
                LocaleTable.Add("WRITER_LABEL_MESSAGE", "Message");
                LocaleTable.Add("WRITER_CHECKBOX_AGREEMENT", "I agree to 'Terms of Use' and 'Privacy Policy'");
                LocaleTable.Add("WRITER_MESSAGE_AGREEMENT", "You must agree to 'Terms of Use' and 'Privacy Policy'");
                LocaleTable.Add("WRITER_MESSAGE_SENT", "Succeed");
                LocaleTable.Add("WRITER_LABEL_TITLE", "Write a comment");
                LocaleTable.Add("WRITER_LABEL_REPLAY_EMAIL", "Email (Optional, If you need a reply)");
                LocaleTable.Add("WRITER_TITLE", "Write a comment");
                LocaleTable.Add("AUTH_BUTTON_LOGIN", "Log In");
                LocaleTable.Add("AUTH_LABEL_USERNAME", "Email");
                LocaleTable.Add("AUTH_LABEL_PASSWORD", "Password");
                LocaleTable.Add("AUTH_LABEL_TITLE", "Authorization");
                LocaleTable.Add("AUTH_LABEL_COPYRIGHT", "(c) Catswords Community, OSL");
                LocaleTable.Add("AUTH_TITLE", "Authorization");
                LocaleTable.Add("AUTH_MESSAGE_LOGIN_SUCCEED", "Succeed");
                LocaleTable.Add("AUTH_MESSAGE_LOGIN_FAILED", "Failed");
                LocaleTable.Add("EXPERT_LABEL_TITLE", "Expert mode");
                LocaleTable.Add("EXPERT_BUTTON_LOGIN", "Log In");
                LocaleTable.Add("EXPERT_TITLE", "Expert mode");
                LocaleTable.Add("EXPERT_TABPAGE_QUERY", "Query");
                LocaleTable.Add("EXPERT_TAGPAGE_REPORT", "Report");
                LocaleTable.Add("EXPERT_LABEL_MD5", "MD5");
                LocaleTable.Add("EXPERT_LABEL_SHA1", "SHA1");
                LocaleTable.Add("EXPERT_LABEL_CRC32", "CRC32");
                LocaleTable.Add("EXPERT_LABEL_HEAD32", "HEAD32");
                LocaleTable.Add("EXPERT_LABEL_EXTENSION", "Extension");
                LocaleTable.Add("EXPERT_LABEL_LANGUAGE", "Language");
                LocaleTable.Add("EXPERT_BUTTON_QUERY", "Do Query");
            }
        }

        public static string GetConfig(string name)
        {
            string text = "";

            if (ConfigTable != null && ConfigTable.ContainsKey(name))
            {
                text = ConfigTable[name];
            }

            return text;
        }

        public static string GetLocalization(string name)
        {
            string text = "";

            if (LocaleTable != null && LocaleTable.ContainsKey(name))
            {
                text = LocaleTable[name];
            }

            return text;
        }

        // https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file
        public static string GetFileMd5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static string GetFileSha1(string filename)
        {
            using (var sha1 = SHA1.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static string GetFileCrc32(string filename)
        {
            return ""; // Not supported in GAC mode
        }

        // https://stackoverflow.com/questions/7514101/how-do-i-read-exactly-n-bytes-from-a-stream
        public static string GetFileHead32(string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                int count = 32;

                byte[] buffer = new byte[count];
                int offset = 0;
                while (offset < count)
                {
                    int read = stream.Read(buffer, offset, count - offset);
                    if (read == 0)
                        throw new System.IO.EndOfStreamException();
                    offset += read;
                }
                System.Diagnostics.Debug.Assert(offset == count);

                return Convert.ToBase64String(buffer);
            }
        }

        public static string GetFileSha256(string filename)
        {
            using (var sha256 = SHA256.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = sha256.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public static string GetFileExtension(string filename)
        {
            return Path.GetExtension(filename).Substring(1).ToUpper();
        }

        // http://www.csharpstudy.com/web/article/16-HttpWebRequest-%ED%99%9C%EC%9A%A9
        public static string RequestGet(string uri)
        {
            string responseText = string.Empty;
            string requestUrl = GetConfig("BASE_URL") + uri;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "GET";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab.Shell/1.1 (https://catswords.com)";
            if(!GetAuthToken().Equals(string.Empty))
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
            string requestUrl = GetConfig("BASE_URL") + uri;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab.Shell/1.1 (https://catswords.com)";
            if(!GetAuthToken().Equals(string.Empty))
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

        public static Font GetFont(float size = 9F)
        {
            return new Font(pfc.Families[0], size);
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
            return GetConfig("AUTH_TYPE") + " " + GetAuthToken();
        }

        public static void DoLogin(string username, string password)
        {
            JObject JsonData = new JObject
            {
                { "email", username },
                { "password", password }
            };
            string response = Helper.RequestPost(GetConfig("AUTH_REQUEST_URI"), JsonData.ToString());
            Helper.SetAuthToken(response);
        }
        
        public static string GetCurrentLanaguage()
        {
            CultureInfo ci = CultureInfo.CurrentUICulture;
            return ci.Name;
        }
    }
}
