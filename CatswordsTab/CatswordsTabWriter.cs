﻿using CatswordsTab.model;
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
    public partial class CatswordsTabWriter : Form
    {
        private CatswordsTabPage tabPage;

        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public CatswordsTabWriter()
        {
            Initialize();
        }

        public CatswordsTabWriter(CatswordsTabPage catswordsTabPage)
        {
            Initialize();
            this.tabPage = catswordsTabPage;
        }

        private void InitializeLocalization()
        {
            btnSend.Text = "저장";
            labelMessage.Text = "남기실 말";
            cbPrivacy.Text = "개인정보 수집 및 이용 약관에 동의합니다.";
            labelTitle.Text = "의견작성";
        }

        private void InitializeFont()
        {
            this.Font = CatswordsTabHelper.GetFont();
            btnSend.Font = CatswordsTabHelper.GetFont(12F);
            labelMessage.Font = CatswordsTabHelper.GetFont();
            cbPrivacy.Font = CatswordsTabHelper.GetFont();
            labelTitle.Font = CatswordsTabHelper.GetFont(20F);
            txtMessage.Font = CatswordsTabHelper.GetFont();
        }

        private void CatswordsTabWriter_Load(object sender, EventArgs e)
        {

        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            TabItem obj = new TabItem();
            obj.HashMd5 = tabPage.FileMd5;
            obj.HashSha1 = tabPage.FileSha1;
            obj.HashHead32 = tabPage.FileHead32;
            obj.Extension = tabPage.FileExt;
            obj.HashCrc32 = tabPage.FileCrc32;
            obj.Message = txtMessage.Text;

            string jsonData = obj.ToJson();

            tabPage.SetTxtTerminalText(jsonData);
        }
    }
}
