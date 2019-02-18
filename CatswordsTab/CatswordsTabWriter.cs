using CatswordsTab.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab
{
    public partial class CatswordsTabWriter : Form
    {
        private CatswordsTabPage tabPage;

        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public CatswordsTabWriter()
        {
            Initialize();
        }

        public CatswordsTabWriter(CatswordsTabPage catswordsTabPage)
        {
            Initialize();
            tabPage = catswordsTabPage;
        }

        public void setTxtReplyEmail(string email)
        {
            txtReplyEmail.Text = email;
        }

        private void InitializeLocalization()
        {
            btnSend.Text = "저장";
            labelMessage.Text = "남기실 말";
            cbAgreement.Text = "개인정보 수집 및 이용 약관에 동의합니다.";
            labelTitle.Text = "의견작성";
            labelReplyEmail.Text = "회신 전자우편 주소 (선택)";
            this.Text = "의견작성";
        }

        private void InitializeFont()
        {
            this.Font = CatswordsTabHelper.GetFont();
            btnSend.Font = CatswordsTabHelper.GetFont(12F);
            labelMessage.Font = CatswordsTabHelper.GetFont();
            cbAgreement.Font = CatswordsTabHelper.GetFont();
            labelTitle.Font = CatswordsTabHelper.GetFont(20F);
            labelReplyEmail.Font = CatswordsTabHelper.GetFont();
            txtMessage.Font = CatswordsTabHelper.GetFont();
        }

        private void OpenAuthWindow()
        {
            CatswordsTabAuth AuthWindow = new CatswordsTabAuth(this);
            AuthWindow.Show();
        }

        private void OpenExpertWindow()
        {
            CatswordsTabExpert ExpertWindow = new CatswordsTabExpert(this);
            ExpertWindow.Show();
        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMessage;

            // login by guest credential
            try
            {
                CatswordsTabHelper.DoLogin("guest.tab@catswords.com", "d3nexkz9UkP8ur77");
            } catch
            {
                OpenAuthWindow();
            }
            
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cbAgreement.Checked == false)
            {
                MessageBox.Show("개인정보 수집 및 이용 약관에 동의하셔야 합니다.");
            }
            else
            {
                TabItem obj = new TabItem();
                obj.HashMd5 = tabPage.FileMd5;
                obj.HashSha1 = tabPage.FileSha1;
                obj.HashCrc32 = tabPage.FileCrc32;
                obj.HashSha256 = tabPage.FileSha256;
                obj.HashHead32 = tabPage.FileHead32;
                obj.Extension = tabPage.FileExt;
                obj.Message = txtMessage.Text;
                obj.ReplyEmail = txtReplyEmail.Text;
                obj.Language = tabPage.DeviceLanguage;
                string jsonData = obj.ToJson();
                string response = CatswordsTabHelper.RequestPost("/_/items/catswords_tab", jsonData);
                TabResponse jsonResponse = JsonConvert.DeserializeObject<TabResponse>(response);
                if (jsonResponse.Data.Id > 0)
                {
                    tabPage.InitializeTerminal();
                    MessageBox.Show("등록이 완료되었습니다.");
                    this.Close();
                }
            }
        }

        private void txtReplyEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtReplyEmail.Text.ToLower();

            if (email == "/login")
            {
                OpenAuthWindow();
            }

            if(email == "/expert")
            {
                OpenExpertWindow();
            }
        }
    }
}
