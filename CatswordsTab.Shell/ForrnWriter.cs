using CatswordsTab.Shell.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.Shell
{
    public partial class ForrnWriter : Form
    {
        private string dataReport = "";
   
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public ForrnWriter()
        {
            Initialize();
        }

        public void setTxtReplyEmail(string email)
        {
            txtReplyEmail.Text = email;
        }

        private void InitializeLocalization()
        {
            btnSend.Text = Helper.GetLocalization("WRITER_BUTTON_SEND");
            labelMessage.Text = Helper.GetLocalization("WRITER_LABEL_MESSAGE");
            cbAgreement.Text = Helper.GetLocalization("WRITER_CHECKBOX_AGREEMENT");
            labelTitle.Text = Helper.GetLocalization("WRITER_LABEL_TITLE");
            labelReplyEmail.Text = Helper.GetLocalization("WRITER_LABEL_REPLAY_EMAIL");
            Text = Helper.GetLocalization("WRITER_TITLE");
        }

        private void InitializeFont()
        {
            this.Font = Helper.GetFont();
            btnSend.Font = Helper.GetFont(12F);
            labelMessage.Font = Helper.GetFont();
            cbAgreement.Font = Helper.GetFont();
            labelTitle.Font = Helper.GetFont(20F);
            labelReplyEmail.Font = Helper.GetFont();
            txtMessage.Font = Helper.GetFont();
        }

        private void OpenAuthWindow()
        {
            Helper.TabAuth = new FormAuth();
            Helper.TabAuth.Show();
        }

        private void OpenExpertWindow()
        {
            Helper.TabExpert = new FormExpert();
            Helper.TabExpert.Show();
        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {
            Helper.TabWriter = this;
            ActiveControl = txtMessage;

            try
            {
                Helper.DoLogin(Helper.GetConfig("DEFAULT_USERNAME"), Helper.GetConfig("DEFAULT_PASSWORD"));
            } catch
            {
                // open auth window
                OpenAuthWindow();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            if (cbAgreement.Checked == false)
            {
                MessageBox.Show(Helper.GetLocalization("WRITER_MESSAGE_AGREEMENT"));
            }
            else
            {
                // write data
                TabItem obj = new TabItem
                {
                    HashMd5 = Helper.TabPage.FileMd5,
                    HashSha1 = Helper.TabPage.FileSha1,
                    HashCrc32 = Helper.TabPage.FileCrc32,
                    HashSha256 = Helper.TabPage.FileSha256,
                    HashHead32 = Helper.TabPage.FileHead32,
                    Extension = Helper.TabPage.FileExt,
                    Message = txtMessage.Text,
                    ReplyEmail = txtReplyEmail.Text,
                    Language = Helper.TabPage.CurrentLanguage,
                    Report = Helper.ReportData,
                };
                string jsonData = obj.ToJson();
                string response = Helper.RequestPost("/_/items/catswords_tab", jsonData);
                TabResponse jsonResponse = JsonConvert.DeserializeObject<TabResponse>(response);
                if (jsonResponse.Data.Id > 0)
                {
                    Helper.TabPage.InitializeTerminal();
                    MessageBox.Show(Helper.GetLocalization("WRITER_MESSAGE_SENT"));
                    this.Close();
                }
            }
        }

        private void txtReplyEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtReplyEmail.Text.ToLower();

            if(email == "/expert")
            {
                OpenExpertWindow();
            }
        }
    }
}
