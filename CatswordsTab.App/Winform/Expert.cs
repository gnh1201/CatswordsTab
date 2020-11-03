using CatswordsTab.App.Model;
using RestSharp;
using System;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Expert : Form
    {
        private ComputationModel _computed;

        public Expert()
        {
            InitializeComponent();
        }
        
        private void OnLoad_Expert(object sender, EventArgs e)
        {
            _computed = WinformService.GetMainWindow().GetComputed();

            this.Text = T._(this.Text);
            labelTitle.Text = T._(labelTitle.Text);
            btnSubmit.Text = T._(btnSubmit.Text);
            btnOpenSolver.Text = T._(btnOpenSolver.Text);
            btnOpenApplication.Text = T._(btnOpenApplication.Text);
            btnOpenAssociation.Text = T._(btnOpenAssociation.Text);

            txtExtension.Text = _computed.Extension;
            txtHashMd5.Text = _computed.MD5;
            txtHashSha1.Text = _computed.SHA1;
            txtHashCrc32.Text = _computed.CRC32;
            txtHashSha256.Text = _computed.SHA256;
            txtHashHead32.Text = _computed.HEAD32;;
            txtInfoHash.Text = _computed.InfoHash;
            txtLocale.Text = _computed.SystemLocale;
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
            request.AddParameter("infohash", txtInfoHash.Text);
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

        private void OnClick_btnOpenSolver(object sender, EventArgs e)
        {
            WinformService.GetSolverWindow().Show();
        }

        private void OnClick_btnOpenAppliance(object sender, EventArgs e)
        {
            WinformService.GetApplianceWindow().Show();
        }

        private void OnClick_btnOpenAssociation(object sender, EventArgs e)
        {
            WinformService.GetAssociationWindow().Show();
        }
    }
}
