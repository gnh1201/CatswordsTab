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
        public Auth()
        {
            InitializeComponent();
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
        
        private void OnClick_btnLogin(object sender, EventArgs e)
        {
            try { 
                MessageBox.Show("로그인 하였습니다.");
                this.Close();
            } catch
            {
                MessageBox.Show("사용자 이름 또는 열쇠글을 확인하세요.");
            }
            
        }

        private void OnLoad_Auth(object sender, EventArgs e)
        {
            // nothing
        }
    }
}
