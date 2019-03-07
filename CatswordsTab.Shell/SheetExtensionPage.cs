using NetMQ;
using NetMQ.Sockets;
using SharpShell.SharpPropertySheet;
using System;
using System.Linq;

namespace CatswordsTab.Shell
{
    public partial class SheetExtensionPage : SharpPropertyPage
    {
        private string FilePath = "";

        public void SendMessage(string message)
        {
            using (var client = new RequestSocket(">tcp://localhost:26112"))
            {
                client.SendFrame(message);
            }
        }

        public SheetExtensionPage()
        {
            InitializeComponent();
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            FilePath = parent.SelectedItemPaths.First();
            this.SendMessage(FilePath);
            this.SendMessage("CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised");
        }

        protected override void OnPropertySheetApply()
        {
            this.SendMessage("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply");
        }

        protected override void OnPropertySheetOK()
        {
            this.SendMessage("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK");
        }

        private void OnClick_btnAdd(object sender, EventArgs e)
        {
            this.SendMessage("CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd");
        }

        private void OnLoad_CatswordsTabPage(object sender, EventArgs e)
        {
            PageTitle = "커뮤니티";
            btnAdd.Text = "의견작성";
            labelTitle.Text = "커뮤니티";
            this.SendMessage("CatswordsTab.Shell.SheetExtensionPage.OnLoad_CatswordsTabPage");
        }
    }
}
