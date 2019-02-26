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
using Newtonsoft.Json;
using Force.Crc32;
using System.Globalization;
using PeNet;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;

namespace CatswordsTab.Shell
{
    public static class CatswordsTabHelper
    {
        private static string AuthType = "bearer";
        private static string AuthToken = string.Empty;
        private static string BaseUri = "https://2s.re.kr";
        private static PrivateFontCollection pfc = null;
        public static CatswordsTabPage TabPage = null;
        public static CatswordsTabAuth TabAuth = null;
        public static CatswordsTabWriter TabWriter = null;
        public static CatswordsTabExpert TabExpert = null;
        public static string ReportData = "";
        public static string EOL = "\r\n";

        static CatswordsTabHelper()
        {
            // set font collection
            pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.NotoSansCJKkr_Regular.Length;
            byte[] fontdata = Properties.Resources.NotoSansCJKkr_Regular;
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
        }

        public static byte[] ConvertStreamToBytes(Stream stream)
        {
            // https://stackoverflow.com/questions/11266141/c-sharp-convert-system-io-stream-to-byte
            stream.Position = 0;
            byte[] buffer = new byte[stream.Length];
            for (int totalBytesCopied = 0; totalBytesCopied < stream.Length;)
                totalBytesCopied += stream.Read(buffer, totalBytesCopied, Convert.ToInt32(stream.Length) - totalBytesCopied);
            return buffer;
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
            using (var crc32 = new Crc32Algorithm())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = crc32.ComputeHash(ConvertStreamToBytes(stream));
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
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

        // alternative to RestSharp
        // http://www.csharpstudy.com/web/article/16-HttpWebRequest-%ED%99%9C%EC%9A%A9
        public static string RequestGet(string uri)
        {
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUri + uri);
            request.Method = "GET";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab/1.0 (https://catswords.com)";
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUri + uri);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab/1.0 (https://catswords.com)";
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
            return AuthType + " " + GetAuthToken();
        }

        public static void DoLogin(string username, string password)
        {
            JObject JsonData = new JObject
            {
                { "email", username },
                { "password", password }
            };
            string response = CatswordsTabHelper.RequestPost("/_/auth/authenticate", JsonData.ToString());
            CatswordsTabHelper.SetAuthToken(response);
        }
        
        public static string GetCurrentLanaguage()
        {
            CultureInfo ci = CultureInfo.CurrentUICulture;
            return ci.Name;
        }

        public static void DoAnalyze()
        {
            // PE Header
            ReportData += "## PE Header" + EOL;
            try
            {
                PeFile pe = new PeNet.PeFile(CatswordsTabHelper.TabPage.FilePath);
                ReportData += pe.ToString() + EOL;
            } catch
            {
                ReportData += "Some occured errors." + EOL;
            }

            // ELF
            try
            {
                IELF elf = ELFReader.Load(CatswordsTabHelper.TabPage.FilePath);

                // ELF Section Header
                ReportData += "## ELF Section Header" + EOL;
                foreach (ISection header in elf.Sections)
                {
                    ReportData += header.ToString() + EOL;
                }

                // ELF Functions
                ReportData += "## ELF Function" + EOL;
                var functions = ((ISymbolTable)elf.GetSection(".symtab")).Entries.Where(x => x.Type == SymbolType.Function);
                foreach (ISymbolEntry f in functions)
                {
                    ReportData += f.Name + EOL;
                }
            } catch
            {
                ReportData += "Some occured errors." + EOL;
            }
        }
    }
}
