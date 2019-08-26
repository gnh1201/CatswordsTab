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
        private ComputationModel _computed;
        private string _result;

        public Writer()
        {
            InitializeComponent();
        }

        private void OnLoad_Writer(object sender, EventArgs e)
        {
            _computed = WinformService.GetMainWindow().GetComputed();

            Text = T._(Text);
            labelTitle.Text = T._(labelTitle.Text);
            labelMessage.Text = T._(labelMessage.Text);
            labelReplyEmail.Text = T._(labelReplyEmail.Text);
            cbAgreement.Text = T._(cbAgreement.Text);
            btnSend.Text = T._(btnSend.Text);
        }

        private void OnClick_btnSend(object sender, EventArgs e)
        {
            btnSend.Enabled = false;

            if (!cbAgreement.Checked)
            {
                MessageBox.Show(T._("You must accept to the Terms and Conditions and Privacy Policy"));
                btnSend.Enabled = true;
            }
            else
            {
                // store message to offline database
                using (LiteDatabase db = new LiteDatabase(@"AppData.db"))
                {
                    var messages = db.GetCollection<MessageModel>("messages");
                    MessageModel message = new MessageModel
                    {
                        Message = txtMessage.Text,
                        ReplyEmail = txtReplyEmail.Text,
                        HashMD5 = _computed.MD5,
                        HashSHA256 = _computed.SHA256,
                        HashCRC32 = _computed.CRC32,
                        HashSHA1 = _computed.SHA1,
                        HashHEAD32 = _computed.HEAD32,
                        InfoHash = _computed.InfoHash,
                        Extension = _computed.Extension,
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
                request.AddParameter("hash_md5", _computed.MD5);
                request.AddParameter("hash_sha1", _computed.SHA1);
                request.AddParameter("hash_crc32", _computed.CRC32);
                request.AddParameter("hash_sha256", _computed.SHA256);
                request.AddParameter("hash_head32", _computed.HEAD32);
                request.AddParameter("extension", _computed.Extension);
                request.AddParameter("infohash", _computed.InfoHash);
                request.AddParameter("locale", T.GetLocale());
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
