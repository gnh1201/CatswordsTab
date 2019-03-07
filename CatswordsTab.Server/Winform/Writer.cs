using CatswordsTab.Server.Model;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using Newtonsoft.Json;
using PeNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.Server
{
    public partial class CatswordsTabWriter : Form
    {
        private string dataReport = "";
   
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

        }

        private void OpenAuthWindow()
        {

        }

        private void OpenExpertWindow()
        {

        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
            if (cbAgreement.Checked == false)
            {
                MessageBox.Show("개인정보 수집 및 이용 약관에 동의하셔야 합니다.");
            }
            else
            {
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
