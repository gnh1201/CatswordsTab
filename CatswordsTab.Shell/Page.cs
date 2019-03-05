using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpShell.SharpPropertySheet;
using System.Security.Cryptography;
using System.IO;
using Newtonsoft.Json.Linq;

namespace CatswordsTab.Shell
{
    public partial class Page : SharpPropertyPage
    {
        public string FilePath;
        public string FileMd5;
        public string FileSha1;
        public string FileExt;
        public string FileCrc32;
        public string FileSha256;
        public string FileHead32;
        public string CurrentLanguage;

        public Page()
        {
            InitializeComponent();
            InitializeLocalzation();
            InitializeFont();
        }

        private void InitializeLocalzation()
        {
            PageTitle = Helper.GetLocalization("PAGE_TITLE");
            btnAdd.Text = Helper.GetLocalization("PAGE_BUTTON_ADD");
            labelTitle.Text = Helper.GetLocalization("PAGE_LABEL_TITLE");
        }

        private void InitializeFont()
        {
            this.Font = Helper.GetFont();
            btnAdd.Font = Helper.GetFont(12F);
            labelTitle.Font = Helper.GetFont(20F);
            txtTerminal.Font = Helper.GetFont();
        }

        public void SetTxtTerminalText(string text)
        {
            txtTerminal.Text = text;
        }

        public void InitializeTerminal()
        {
            JObject obj = new JObject
            {
                { "hash_md5", FileMd5 },
                { "hash_sha1", FileSha1 },
                { "hash_crc32", FileCrc32 },
                { "hash_sha256", FileSha256 },
                { "hash_head32", FileHead32 },
                { "extension", FileExt },
                { "language", CurrentLanguage }
            };
            string response = Helper.RequestPost(Helper.GetConfig("PAGE_REQUEST_URI"), obj.ToString());
            txtTerminal.Text = response;
            txtTerminal.Enabled = true;
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            FilePath = parent.SelectedItemPaths.First();
            FileMd5 = Helper.GetFileMd5(FilePath);
            FileSha1 = Helper.GetFileSha1(FilePath);
            FileExt = Helper.GetFileExtension(FilePath);
            FileCrc32 = Helper.GetFileCrc32(FilePath);
            FileSha256 = Helper.GetFileSha256(FilePath);
            FileHead32 = Helper.GetFileHead32(FilePath);
            CurrentLanguage = Helper.GetCurrentLanaguage();
            InitializeTerminal();
        }

        protected override void OnPropertySheetApply()
        {
            // insert your code
        }

        protected override void OnPropertySheetOK()
        {
            // insert your code
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.TabWriter = new ForrnWriter();
            Helper.TabWriter.Show();
        }

        private void CatswordsTabPage_Load(object sender, EventArgs e)
        {
            Helper.TabPage = this;
            ActiveControl = null;
        }

    }
}
