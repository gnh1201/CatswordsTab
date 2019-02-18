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
    public partial class CatswordsTabExpert : Form
    {
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalzation();
            InitializeFont();
        }

        public CatswordsTabExpert()
        {
            Initialize();
        }
        
        private void InitializeLocalzation()
        {
            this.Text = "전문가 모드";
            labelTitle.Text = "전문가 모드";
            btnLogin.Text = "로그인";
        }

        private void InitializeFont()
        {
            this.Font = CatswordsTabHelper.GetFont();
            labelTitle.Font = CatswordsTabHelper.GetFont(20F);
            btnLogin.Font = CatswordsTabHelper.GetFont(12F);
        }

        private void OpenAuthWindow()
        {
            CatswordsTabAuth AuthWindow = new CatswordsTabAuth();
            AuthWindow.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenAuthWindow();
        }
    }
}
