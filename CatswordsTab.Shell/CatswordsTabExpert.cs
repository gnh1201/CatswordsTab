using Newtonsoft.Json.Linq;
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
            CatswordsTabHelper.TabAuth = new CatswordsTabAuth();
            CatswordsTabHelper.TabAuth.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenAuthWindow();
        }

        private void CatswordsTabExpert_Load(object sender, EventArgs e)
        {
            CatswordsTabHelper.TabExpert = this;
            txtHashMd5.Text = CatswordsTabHelper.TabPage.FileMd5;
            txtHashSha1.Text = CatswordsTabHelper.TabPage.FileSha1;
            txtHashCrc32.Text = CatswordsTabHelper.TabPage.FileCrc32;
            txtHashHead32.Text = CatswordsTabHelper.TabPage.FileHead32;
            txtHashSha256.Text = CatswordsTabHelper.TabPage.FileSha256;
            txtExtension.Text = CatswordsTabHelper.TabPage.FileExt;
            txtLanguage.Text = CatswordsTabHelper.TabPage.CurrentLanguage;
            txtAnalytics.Text = CatswordsTabHelper.ReportData;
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            JObject obj = new JObject
            {
                { "hash_md5", txtHashMd5.Text },
                { "hash_sha1", txtHashSha1.Text },
                { "hash_crc32", txtHashCrc32.Text },
                { "hash_sha256", txtHashSha256.Text },
                { "hash_head32", txtHashHead32.Text },
                { "extension", txtExtension.Text },
                { "language", txtLanguage.Text }
            };
            string response = CatswordsTabHelper.RequestPost("/portal/?route=tab", obj.ToString());
            CatswordsTabHelper.TabPage.SetTxtTerminalText(response);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            CatswordsTabHelper.DoAnalyze();
            txtAnalytics.Text = CatswordsTabHelper.ReportData;
        }
    }
}
