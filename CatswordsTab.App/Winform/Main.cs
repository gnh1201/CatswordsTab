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
        private string _result = Properties.Resources.txtTerminal_en;

        public Main()
        {
            ChooseTargetFile();
            InitializeComponent();
            WinformService.SetMainWindow(this);
            SetTxtTerminal(GetResult());
        }

        private void ChooseTargetFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Open Target File";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                SetPath(fd.FileName);
                SetResult();
            }
            else
            {
                ChooseTargetFile();
            }
        }

        private void SetResult()
        {
            _computed = ComputeService.Compute(_path);

            RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("hash_md5", _computed["md5"]);
            request.AddParameter("hash_sha1", _computed["sha1"]);
            request.AddParameter("hash_crc32", _computed["crc32"]);
            request.AddParameter("hash_sha256", _computed["sha256"]);
            request.AddParameter("extension", _computed["extension"]);
            request.AddParameter("infohash", _computed["infohash"]);
            request.AddParameter("locale", _computed["locale"]);

            // get summary
            IRestResponse response = client.Execute(request);
            _result = response.Content;
        }

        private void OnClick_btnWriter(object sender, EventArgs e)
        {
            WinformService.GetWriterWindow().Show();
        }

        private void OnLoad_Main(object sender, EventArgs e)
        {
            if(_computed["locale"] == "ko")
            {
                this.Text = "캐츠워즈 탭: 커뮤니티";
                labelTitle.Text = "커뮤니티";
                btnWriter.Text = "의견작성";
                linkLabel2.Text = "이 프로젝트에 기여";
                tabPage1.Text = "요약";
                tabPage2.Text = "16진수";
            } else
            {
                this.Text = "CatswordsTab: Community";
            }

            // Gex HEX data (limit 8K)
            textBox1.Text = ComputeService.GetHexView(ComputeService.GetFileBytes(_path, 8192));
        }

        private void OnDblClick_labelTitle(object sender, EventArgs e)
        {
            WinformService.GetExpertWindow().Show();
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
            System.Diagnostics.Process.Start("https://catswords.com");
        }

        private void OnClick_linkLabel2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/gnh1201/CatswordsTab");
        }
    }
}
