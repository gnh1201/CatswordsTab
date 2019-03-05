using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CatswordsTab.Server.Response;

namespace CatswordsTab.Server.Winform
{
    public partial class Auth : Form
    {
        private CatswordsTabWriter CatswordsTabWriter = null;

        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public Auth()
        {
            Initialize();
        }

        private void InitializeLocalization()
        {
            btnLogin.Text = "로그인";
            labelUsername.Text = "사용자 이메일";
            labelPassword.Text = "사용자 열쇠글";
            labelTitle.Text = "인증";
            labelCopyright.Text = "(c) 2019 Catswords Research.";
            this.Text = "인증";
        }

        private void InitializeFont()
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try { 
                MessageBox.Show("로그인 하였습니다.");

                if (CatswordsTabWriter != null)
                {
                    CatswordsTabWriter.setTxtReplyEmail(txtUsername.Text);
                }

                this.Close();
            } catch
            {
                MessageBox.Show("사용자 이름 또는 열쇠글을 확인하세요.");
            }
            
        }

        private void CatswordsTabAuth_Load(object sender, EventArgs e)
        {

        }
    }
}
