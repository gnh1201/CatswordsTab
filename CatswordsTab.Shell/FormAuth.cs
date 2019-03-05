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

namespace CatswordsTab.Shell
{
    public partial class FormAuth : Form
    {
        private ForrnWriter CatswordsTabWriter = null;

        private void Initialize()
        {
            InitializeComponent();
            InitializeLocalization();
            InitializeFont();
        }

        public FormAuth()
        {
            Initialize();
        }

        private void InitializeLocalization()
        {
            btnLogin.Text = Helper.GetLocalization("AUTH_BUTTON_LOGIN");
            labelUsername.Text = Helper.GetLocalization("AUTH_LABEL_USERNAME");
            labelPassword.Text = Helper.GetLocalization("AUTH_LABEL_PASSWORD");
            labelTitle.Text = Helper.GetLocalization("AUTH_LABEL_TITLE");
            labelCopyright.Text = Helper.GetLocalization("AUTH_LABEL_COPYRIGHT");
            Text = Helper.GetLocalization("AUTH_TITLE");
        }

        private void InitializeFont()
        {
            this.Font = Helper.GetFont();
            labelTitle.Font = Helper.GetFont(20F);
            btnLogin.Font = Helper.GetFont(12F);
            labelUsername.Font = Helper.GetFont();
            labelPassword.Font = Helper.GetFont();
            labelCopyright.Font = Helper.GetFont();
            txtUsername.Font = Helper.GetFont();
            txtPassword.Font = Helper.GetFont();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try { 
                Helper.DoLogin(txtUsername.Text, txtPassword.Text);
                MessageBox.Show(Helper.GetLocalization("AUTH_MESSAGE_LOGIN_SUCCEED"));

                if (CatswordsTabWriter != null)
                {
                    CatswordsTabWriter.setTxtReplyEmail(txtUsername.Text);
                }

                this.Close();
            } catch
            {
                MessageBox.Show(Helper.GetLocalization("AUTH_MESSAGE_LOGIN_FAILED"));
            }
            
        }

        private void CatswordsTabAuth_Load(object sender, EventArgs e)
        {
            Helper.TabAuth = this;
        }
    }
}
