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

namespace CatswordsTab
{
    public partial class CatswordsTabPage : SharpPropertyPage
    {
        public string FilePath;
        public string FileMd5;
        public string FileSha1;
        public string FileExt;
        public string FileCrc32;
        public string FileSha256;
        public string FileHead32;
        public string CurrentLanguage;

        public CatswordsTabPage()
        {
            InitializeComponent();
            InitializeLocalzation();
            InitializeFont();
        }

        private void InitializeLocalzation()
        {
            PageTitle = "커뮤니티";
            btnAdd.Text = "의견작성";
            labelTitle.Text = "커뮤니티";
        }

        private void InitializeFont()
        {
            this.Font = CatswordsTabHelper.GetFont();
            btnAdd.Font = CatswordsTabHelper.GetFont(12F);
            labelTitle.Font = CatswordsTabHelper.GetFont(20F);
            txtTerminal.Font = CatswordsTabHelper.GetFont();
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
            string response = CatswordsTabHelper.RequestPost("/portal/?route=tab", obj.ToString());
            txtTerminal.Text = response;
            txtTerminal.Enabled = true;
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            FilePath = parent.SelectedItemPaths.First();
            FileMd5 = CatswordsTabHelper.GetFileMd5(FilePath);
            FileSha1 = CatswordsTabHelper.GetFileSha1(FilePath);
            FileExt = CatswordsTabHelper.GetFileExtension(FilePath);
            FileCrc32 = CatswordsTabHelper.GetFileCrc32(FilePath);
            FileSha256 = CatswordsTabHelper.GetFileSha256(FilePath);
            FileHead32 = CatswordsTabHelper.GetFileHead32(FilePath);
            CurrentLanguage = CatswordsTabHelper.GetCurrentLanaguage();
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
            CatswordsTabWriter writerForm = new CatswordsTabWriter();
            writerForm.Show();
        }

        private void CatswordsTabPage_Load(object sender, EventArgs e)
        {
            CatswordsTabHelper.TabPage = this;
            ActiveControl = null;
        }

    }
}
