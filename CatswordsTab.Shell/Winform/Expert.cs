using System;
using System.Windows.Forms;

namespace CatswordsTab.Shell.Winform
{
    public partial class Expert : Form
    {
        public Expert()
        {
            InitializeComponent();
        }
        
        private void OnClick_btnAuth(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Expert.OnClick_btnAuth");
            MessageService.Commit();
            WinformService.GetAuthWindow().Show();
        }

        private void OnLoad_Expert(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Expert.OnLoad_Expert");
            MessageService.Commit();

            labelTitle.Text = "Expert";
            btnSubmit.Text = "Submit";
            btnAuth.Text = "Authenticate";
        }

        private void OnClick_btnSubmit(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Expert.OnClick_btnSubmit");
            MessageService.Push("hashMd5: " + txtHashMd5.Text);
            MessageService.Push("hashSha1: " + txtHashSha1.Text);
            MessageService.Push("hashCrc32: " + txtHashCrc32.Text);
            MessageService.Push("hashSha256: " + txtHashSha256.Text);
            MessageService.Push("hashHead32: " + txtHashHead32.Text);
            MessageService.Push("extension: " + txtExtension.Text);
            MessageService.Push("language: " + txtLanguage.Text);
            MessageService.Commit();
        }
    }
}
