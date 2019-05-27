using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
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
            SetTxtTerminal(_result);
        }

        private void ChooseTargetFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Open Target File";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                _path = fd.FileName;
                _computed = ComputeService.Compute(_path);

                RestClient client = new RestClient("https://catswords.re.kr/ep/");
                RestRequest request = new RestRequest(Method.POST);
                request.AddParameter("route", "tab");
                request.AddParameter("hash_md5", _computed["md5"]);
                request.AddParameter("hash_sha1", _computed["sha1"]);
                request.AddParameter("hash_crc32", _computed["crc32"]);
                request.AddParameter("hash_sha256", _computed["sha256"]);
                request.AddParameter("hash_extension", _computed["extension"]);
                request.AddParameter("locale", _computed["locale"]);

                IRestResponse response = client.Execute(request);
                _result = response.Content;
            }
            else
            {
                ChooseTargetFile();
            }
        }

        private void SetPath(string path)
        {
            _path = path;
        }

        private void OnClick_btnWriter(object sender, EventArgs e)
        {
            WinformService.GetWriterWindow().Show();
        }

        private void OnLoad_Main(object sender, EventArgs e)
        {
            labelTitle.Text = Properties.Resources.labelTitle_en;
            btnWriter.Text = Properties.Resources.btnWriter_en;
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
    }
}
