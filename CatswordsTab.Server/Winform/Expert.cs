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
        public Expert()
        {
            InitializeComponent();
        }

        private void InitializeLocalzation()
        {
            this.Text = "전문가 모드";
            labelTitle.Text = "전문가 모드";
            btnLogin.Text = "로그인";
        }

        private void OnClick_btnLogin(object sender, EventArgs e)
        {
            FormService.GetAuthWindow().Show();
        }

        private void OnLoad_Expert(object sender, EventArgs e)
        {
            // nothing
        }

        private void OnClick_btnGet(object sender, EventArgs e)
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

        private void OnClick_btnAnalyze(object sender, EventArgs e)
        {

        }
    }
}
