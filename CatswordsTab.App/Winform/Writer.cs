using System;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Writer : Form
    {
        public Writer()
        {
            InitializeComponent();
        }

        private void OnLoad_Writer(object sender, EventArgs e)
        {
            labelTitle.Text = "Comment";
            labelMessage.Text = "Message:";
            labelReplyEmail.Text = "Reply email (Optional):";
            cbAgreement.Text = "I accept the Terms and Conditions and Privacy Policy.";
            btnSend.Text = "Send";
        }

        private void OnClick_btnSend(object sender, EventArgs e)
        {
            btnSend.Enabled = false;
        }

        private void OnChanged_txtReplyEmail(object sender, EventArgs e)
        {
            string email = txtReplyEmail.Text;
            if (email == "/expert")
            {
                WinformService.GetExpertWindow().Show();
            }
        }
        
        public void SetTxtReplyEmail(string email)
        {
            txtReplyEmail.Text = email;
        }
    }
}
