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

namespace CatswordsTab
{
    public partial class CatswordsTabAuth : Form
    {
        private CatswordsTabPage catswordsTabPage = null;

        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public CatswordsTabAuth()
        {
            Initialize();
        }

        public CatswordsTabAuth(CatswordsTabPage catswordsTabPage)
        {
            Initialize();
            this.catswordsTabPage = catswordsTabPage;
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
            this.Font = CatswordsTabHelper.GetFont();
            labelTitle.Font = CatswordsTabHelper.GetFont(20F);
            btnLogin.Font = CatswordsTabHelper.GetFont();
            labelUsername.Font = CatswordsTabHelper.GetFont();
            labelPassword.Font = CatswordsTabHelper.GetFont();
            labelCopyright.Font = CatswordsTabHelper.GetFont();
            txtUsername.Font = CatswordsTabHelper.GetFont();
            txtPassword.Font = CatswordsTabHelper.GetFont();
        }

        private void CatswordsTabAuth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CatswordsTabHelper.DoLogin(txtUsername.Text, txtPassword.Text);
            MessageBox.Show("로그인 요청을 보냈습니다.");
        }
    }
}
