using System;
using System.Windows.Forms;

namespace CatswordsTab.Shell.Winform
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }
        
        private void OnClick_btnLogin(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Auth.OnClick_btnLogin");
            MessageService.Push("username: " + txtUsername.Text);
            MessageService.Push("password: " + txtPassword.Text);
            MessageService.Commit();
        }

        private void OnLoad_Auth(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.Winform.Auth.OnLoad_Auth");
            MessageService.Commit();
        }
    }
}
