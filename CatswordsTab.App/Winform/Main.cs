using CatswordsTab.App.Model;
using LiteDB;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatswordsTab.App
{
    public partial class Main : Form
    {
        private string _path;
        private Dictionary<string, string> _computed;
        private string _result = T._("Loading...");

        public Main(string _path)
        {
            InitializeComponent();
            WinformService.SetMainWindow(this);
            SetPath(_path);
            ReloadResult();
        }

        private void SetResult()
        {
            _computed = ComputeService.Compute(_path);
            _result = "";

            RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("hash_md5", _computed["md5"]);
            request.AddParameter("hash_sha1", _computed["sha1"]);
            request.AddParameter("hash_crc32", _computed["crc32"]);
            request.AddParameter("hash_sha256", _computed["sha256"]);
            request.AddParameter("extension", _computed["extension"]);
            request.AddParameter("infohash", _computed["infohash"]);
            request.AddParameter("locale", T.GetLocale());

            // Get information when online
            IRestResponse response = client.Execute(request);
            if(response.StatusCode == System.Net.HttpStatusCode.OK) {
                WriteResultLine(response.Content);
            }
            // Get information when offline
            else
            {
                WriteResultLine("# CatswordsTab Report (Offline)");
                WriteResultLine();
                WriteResultLine("- MD5: " + _computed["md5"]);
                WriteResultLine("- SHA1: " + _computed["sha1"]);
                WriteResultLine("- CRC32: " + _computed["crc32"]);
                WriteResultLine();
                WriteResultLine(T._("Please check your internet connection"));
                WriteResultLine();
                WriteResultLine("# Comments (Offline)");
                using (LiteDatabase db = new LiteDatabase("@AppData.db"))
                {
                    LiteCollection<MessageModel> messages = db.GetCollection<MessageModel>("messages");
                    IEnumerable<MessageModel> results = messages.Find(x => x.HashMD5.Equals(_computed["md5"]));
                    messages.EnsureIndex(x => x.HashMD5);
                    foreach (MessageModel entry in results)
                    {
                        WriteResultLine("- " + entry.Message + " @" + entry.CreatedOn.ToString());
                    }
                }
            }
        }

        private void OnClick_btnWriter(object sender, EventArgs e)
        {
            WinformService.GetWriterWindow().Show();
        }

        private void OnLoad_Main(object sender, EventArgs e)
        {
            this.Text = T._(this.Text);
            labelTitle.Text = T._(labelTitle.Text);
            btnWriter.Text = T._(btnWriter.Text);
            linkLabel2.Text = T._(linkLabel2.Text);
            tabPage1.Text = T._(tabPage1.Text);
            tabPage2.Text = T._(tabPage2.Text);

            // Gex HEX data (limit 8K)
            textBox1.Text = ComputeService.GetHexView(ComputeService.GetFileBytes(_path, 8192));
        }

        private void OnKeyDown_Main(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void SetPath(string path)
        {
            _path = path;
        }

        public string GetPath()
        {
            return _path;
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
            txtTerminal.Enabled = true;
        }
        
        public void WriteResultLine(string text = "")
        {
            _result = _result + text + "\r\n";
        }

        public Dictionary<string, string> GetComputed()
        {
            return _computed;
        }

        public string GetResult()
        {
            return _result;
        }

        public void ReloadResult()
        {
            SetResult();
            SetTxtTerminal(GetResult());
        }

        private void OnClick_linkLabel1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }

        private void OnClick_linkLabel2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }

        private void OnClick_LabelTitle(object sender, EventArgs e)
        {
            WinformService.GetExpertWindow().Show();
        }
    }
}
