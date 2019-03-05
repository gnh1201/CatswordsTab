using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.Server.Winform
{
    public partial class Expert : Form
    {
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalzation();
            InitializeFont();
        }

        public Expert()
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

        }

        private void OpenAuthWindow()
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenAuthWindow();
        }

        private void CatswordsTabExpert_Load(object sender, EventArgs e)
        {
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
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
        }
    }
}
