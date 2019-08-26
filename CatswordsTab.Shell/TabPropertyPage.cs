using System;
using SharpShell.SharpPropertySheet;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Force.Crc32;

namespace CatswordsTab.Shell
{
    public partial class TabPropertyPage : SharpPropertyPage
    {
        private string AppPathFile = AppDataService.GetFilePath("CatswordsTab.App.Path.txt");

        private class FileInfo
        {
            public string Path { get; set; }
            public string MD5 { get; set; }
            public string SHA1 { get; set; }
            public string CRC32 { get; set; }
            public string Extension { get; set; }
        }

        private FileInfo _;

        public TabPropertyPage()
        {
            InitializeComponent();
            PageTitle = T._("Community");
        }

        private string GetAppPath()
        {
            try {
                return File.ReadAllText(AppPathFile);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void SetAppPath(string path)
        {
            File.WriteAllText(AppPathFile, path, Encoding.UTF8);
        }

        private string GetMD5(string filename)
        {
            string checksum = "";

            using (MD5 hasher = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        private string GetSHA1(string filename)
        {
            string checksum = "";

            using (SHA1 hasher = SHA1.Create())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    byte[] hash = hasher.ComputeHash(stream);
                    checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return checksum;
        }

        private static string GetCRC32(string filename)
        {
            string checksum = "";

            using (FileStream stream = File.OpenRead(filename))
            {
                checksum = string.Format("{0:x}", Crc32Algorithm.Compute(stream));
            }

            return checksum;
        }

        private string RequestPost(string url, string data, Dictionary<string, string> headers = null)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Timeout = 30 * 1000;
            request.UserAgent = "CatswordsTab.Shell/1.35-dev (https://github.com/gnh1201/CatswordsTab)";

            // set headers
            if(headers != null) {
                foreach (KeyValuePair<string, string> entry in headers)
                {
                    request.Headers.Add(entry.Key, entry.Value);
                }
            }

            // write stream data
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            request.ContentLength = bytes.Length; // set number of bytes
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(bytes, 0, bytes.Length);
            }

            // processing response data
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

        private string GetExtension(string filename)
        {
            try
            {
                if (Path.GetExtension(filename).Length > 0)
                {
                    return Path.GetExtension(filename).Substring(1).ToUpper();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void TabPropertyPage_Load(object sender, EventArgs e)
        {
            labelTitle.Text = T._(labelTitle.Text);
            btnDetail.Text = T._(btnDetail.Text);
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            _ = new FileInfo();
            _.Path = parent.SelectedItemPaths.First();
            _.MD5 = GetMD5(_.Path);
            _.SHA1 = GetSHA1(_.Path);
            _.CRC32 = GetCRC32(_.Path);
            _.Extension = GetExtension(_.Path);

            JObject json = new JObject
            {
                { "hash_md5", _.MD5 },
                { "hash_sha1", _.SHA1 },
                { "hash_crc32", _.CRC32 },
                { "extension", _.Extension }
            };

            string response = RequestPost("https://catswords.re.kr/ep/?route=tab", json.ToString());
            txtTerminal.Text = response;
            txtTerminal.Enabled = true;
        }

        protected override void OnPropertySheetApply()
        {
            // insert your code
        }

        protected override void OnPropertySheetOK()
        {
            // insert your code
        }

        private void BtnDetail_Click(object sender, EventArgs e)
        {
            string AppExecFile = GetAppPath();

            // step 1. if AppExecFile is null or empty
            if (string.IsNullOrEmpty(AppExecFile))
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Title = T._("Finding CatswordsTab.App.exe file...");
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    SetAppPath(fd.FileName);
                    AppExecFile = GetAppPath();
                }
            }
            else if (!File.Exists(AppExecFile))
            {
                AppExecFile = null;
                SetAppPath("");
                BtnDetail_Click(sender, e);
                return;
            }

            // step 2. if AppExecFile is null or empty
            if (string.IsNullOrEmpty(AppExecFile))
            {
                MessageBox.Show(T._("You have to set path of CatswordsTab.App.exe in order to view details"));
            }
            else
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = GetAppPath();
                startInfo.Arguments = string.Format("--filename \"{0}\"", @_.Path);

                try
                {
                    using (Process proc = Process.Start(startInfo))
                    {
                        proc.WaitForExit();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(T._("Unknown error"));
                }
            } 
        }
    }
}
