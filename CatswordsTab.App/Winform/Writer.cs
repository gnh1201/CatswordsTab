using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Writer : Form
    {
        private Dictionary<string, string> _computed;
        private string _result;

        public Writer()
        {
            InitializeComponent();
        }

        private void OnLoad_Writer(object sender, EventArgs e)
        {
            _computed = WinformService.GetMainWindow().GetComputed();

            if (_computed["locale"] == "ko")
            {
                this.Text = "의견작성";
                labelTitle.Text = "의견작성";
                labelMessage.Text = "의견:";
                labelReplyEmail.Text = "회신 전자우편 (선택):";
                cbAgreement.Text = "이용약관 및 개인정보보호정책에 동의합니다.";
                btnSend.Text = "보내기";
            }
        }

        private void OnClick_btnSend(object sender, EventArgs e)
        {
            if(!cbAgreement.Checked)
            {
                if (_computed["locale"] == "ko")
                {
                    MessageBox.Show("이용약관 및 개인정보보호정책에 동의하여야 합니다.");
                } else {
                    MessageBox.Show("You must accept to the Terms and Conditions and Privacy Policy.");
                }
            }
            else
            {
                btnSend.Enabled = false;

                RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
                RestRequest request = new RestRequest(Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddParameter("action", "comment");
                request.AddParameter("hash_md5", _computed["md5"]);
                request.AddParameter("hash_sha1", _computed["sha1"]);
                request.AddParameter("hash_crc32", _computed["crc32"]);
                request.AddParameter("hash_sha256", _computed["sha256"]);
                request.AddParameter("hash_extension", _computed["extension"]);
                request.AddParameter("locale", _computed["locale"]);
                request.AddParameter("message", txtMessage.Text);
                request.AddParameter("reply_email", txtReplyEmail.Text);

                IRestResponse response = client.Execute(request);
                _result = response.Content;
                MessageBox.Show(_result);
                if (_result == "success")
                {
                    MessageBox.Show("success");
                    WinformService.GetMainWindow().ReloadResult();
                    this.Close();
                }
                else
                {
                    btnSend.Enabled = true;
                    MessageBox.Show("retry");
                }
            }
        }

        private void OnChanged_txtReplyEmail(object sender, EventArgs e)
        {
            string email = txtReplyEmail.Text;
            if (email == "/expert")
            {
                WinformService.GetExpertWindow().Show();
            }
        }

        private void OnKeyDown_Writer(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void SetTxtReplyEmail(string email)
        {
            txtReplyEmail.Text = email;
        }
    }
}
