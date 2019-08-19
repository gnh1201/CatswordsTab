using CatswordsTab.App.Model;
using LiteDB;
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

            this.Text = T._(this.Text, _computed["locale"]);
            labelTitle.Text = T._(labelTitle.Text, _computed["locale"]);
            labelMessage.Text = T._(labelMessage.Text, _computed["locale"]);
            labelReplyEmail.Text = T._(labelReplyEmail.Text, _computed["locale"]);
            cbAgreement.Text = T._(cbAgreement.Text, _computed["locale"]);
            btnSend.Text = T._(btnSend.Text, _computed["locale"]);
        }

        private void OnClick_btnSend(object sender, EventArgs e)
        {
            if(!cbAgreement.Checked)
            {
                MessageBox.Show(T._("You must accept to the Terms and Conditions and Privacy Policy", _computed["locale"]));
            }
            else
            {
                btnSend.Enabled = false;

                // store message to offline database
                using (LiteDatabase db = new LiteDatabase("@AppData.db"))
                {
                    var messages = db.GetCollection<MessageModel>("messages");
                    MessageModel message = new MessageModel
                    {
                        Message = txtMessage.Text,
                        ReplyEmail = txtReplyEmail.Text,
                        HashMD5 = _computed["md5"],
                        HashSHA256 = _computed["sha256"],
                        HashCRC32 = _computed["crc32"],
                        HashSHA1 = _computed["sha1"],
                        HashHEAD32 = _computed["head32"],
                        InfoHash = _computed["infohash"],
                        Extension = _computed["extension"],
                        CreatedOn = DateTime.Now
                    };
                    messages.Insert(message);
                }

                // store message to online database
                RestClient client = new RestClient("https://catswords.re.kr/ep/?route=tab");
                RestRequest request = new RestRequest(Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddParameter("action", "comment");
                request.AddParameter("hash_md5", _computed["md5"]);
                request.AddParameter("hash_sha1", _computed["sha1"]);
                request.AddParameter("hash_crc32", _computed["crc32"]);
                request.AddParameter("hash_sha256", _computed["sha256"]);
                request.AddParameter("hash_head32", _computed["head32"]);
                request.AddParameter("extension", _computed["extension"]);
                request.AddParameter("infohash", _computed["infohash"]);
                request.AddParameter("locale", _computed["locale"]);
                request.AddParameter("message", txtMessage.Text);
                request.AddParameter("reply_email", txtReplyEmail.Text);

                IRestResponse response = client.Execute(request);
                _result = response.Content;

                if (_result == "success")
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Offline mode");
                }

                WinformService.GetMainWindow().ReloadResult();
                this.Close();
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
