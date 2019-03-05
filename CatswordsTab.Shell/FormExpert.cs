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
    public partial class FormExpert : Form
    {
        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalzation();
            InitializeFont();
        }

        public FormExpert()
        {
            Initialize();
        }

        private void InitializeLocalzation()
        {
            Text = Helper.GetLocalization("EXPERT_LABEL_TITLE");
            labelTitle.Text = Helper.GetLocalization("EXPERT_LABEL_TITLE");
            btnLogin.Text = Helper.GetLocalization("EXPERT_BUTTON_LOGIN");
            labelMd5.Text = Helper.GetLocalization("EXPERT_LABEL_MD5");
            labelSha1.Text = Helper.GetLocalization("EXPERT_LABEL_SHA1");
            labelCrc32.Text = Helper.GetLocalization("EXPERT_LABEL_CRC32");
            labelHead32.Text = Helper.GetLocalization("EXPERT_LABEL_CRC32");
            labelExtension.Text = Helper.GetLocalization("EXPERT_LABEL_EXTENSION");
            labelLanguage.Text = Helper.GetLocalization("EXPERT_LABEL_LANGUAGE");
            tpQuery.Text = Helper.GetLocalization("EXPERT_TABPAGE_QUERY");
            tpReport.Text = Helper.GetLocalization("EXPERT_TAGPAGE_REPORT");
            btnQuery.Text = Helper.GetLocalization("EXPERT_BUTTON_QUERY");
        }

        private void InitializeFont()
        {
            this.Font = Helper.GetFont();
            labelTitle.Font = Helper.GetFont(20F);
            btnLogin.Font = Helper.GetFont(12F);
        }

        private void OpenAuthWindow()
        {
            Helper.TabAuth = new FormAuth();
            Helper.TabAuth.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenAuthWindow();
        }

        private void CatswordsTabExpert_Load(object sender, EventArgs e)
        {
            Helper.TabExpert = this;
            txtHashMd5.Text = Helper.TabPage.FileMd5;
            txtHashSha1.Text = Helper.TabPage.FileSha1;
            txtHashCrc32.Text = Helper.TabPage.FileCrc32;
            txtHashHead32.Text = Helper.TabPage.FileHead32;
            txtHashSha256.Text = Helper.TabPage.FileSha256;
            txtExtension.Text = Helper.TabPage.FileExt;
            txtLanguage.Text = Helper.TabPage.CurrentLanguage;
            txtReport.Text = Helper.ReportData;
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
            string response = Helper.RequestPost(Helper.GetConfig("PAGE_REQUEST_URI"), obj.ToString());
            Helper.TabPage.SetTxtTerminalText(response);
        }
    }
}
