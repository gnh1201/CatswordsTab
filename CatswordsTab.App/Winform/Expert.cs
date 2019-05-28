using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Expert : Form
    {
        private Dictionary<string, string> _computed;

        public Expert()
        {
            InitializeComponent();
        }
        
        private void OnLoad_Expert(object sender, EventArgs e)
        {
            _computed = WinformService.GetMainWindow().GetComputed();

            labelTitle.Text = "Expert";
            btnSubmit.Text = "Submit";
            txtExtension.Text = _computed["extension"];
            txtHashMd5.Text = _computed["md5"];
            txtHashSha1.Text = _computed["sha1"];
            txtHashCrc32.Text = _computed["crc32"];
            txtHashSha256.Text = _computed["sha256"];
            txtHashHead32.Text = _computed["head32"];
            txtLocale.Text = _computed["locale"];
        }

        private void OnClick_btnSubmit(object sender, EventArgs e)
        {
            RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
            RestRequest request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("hash_md5", txtHashMd5.Text);
            request.AddParameter("hash_sha1", txtHashSha1.Text);
            request.AddParameter("hash_crc32", txtHashCrc32.Text);
            request.AddParameter("hash_sha256", txtHashSha256.Text);
            request.AddParameter("hash_extension", txtExtension.Text);
            request.AddParameter("locale", txtLocale.Text);

            IRestResponse response = client.Execute(request);
            WinformService.GetMainWindow().SetTxtTerminal(response.Content);
        }

        private void OnKeyDown_Expert(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
