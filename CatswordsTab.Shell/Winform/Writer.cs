using System;
using System.Windows.Forms;

namespace CatswordsTab.Shell.Winform
{
    public partial class Writer : Form
    {
        public Writer()
        {
            InitializeComponent();
        }

        private void OnLoad_Writer(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Writer.OnLoad_Writer");
            MessageService.Commit();

            labelTitle.Text = "Comment";
            labelMessage.Text = "Message:";
            labelReplyEmail.Text = "Reply email (Optional):";
            cbAgreement.Text = "I accept the Terms and Conditions and Privacy Policy.";
            btnSend.Text = "Send";
            btnDonate.Text = "";
        }

        private void OnClick_btnSend(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Writer.OnClick_btnSend");
            MessageService.Push("message: " + txtMessage.Text);
            MessageService.Push("replyEmail: " + txtReplyEmail.Text);
            MessageService.Commit();

            btnSend.Enabled = false;
            WinformService.GetSheetPage().ReloadPage();
        }

        private void OnChanged_txtReplyEmail(object sender, EventArgs e)
        {
            string email = txtReplyEmail.Text; // case sensitive
            if (email == "/expert")
            {
                WinformService.GetExpertWindow().Show();
            }
        }

        private void OnClick_btnDonate(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Writer.OnClick_btnDonate");
            MessageService.Commit();
        }
        
        public void SetTxtReplyEmail(string email)
        {
            txtReplyEmail.Text = email;
        }
    }
}
