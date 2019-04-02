using SharpShell.SharpPropertySheet;
using System;
using System.Linq;

namespace CatswordsTab.Shell
{
    public partial class SheetExtensionPage : SharpPropertyPage
    {
        private string FilePath;
        private string Locale = MessageService.GetLocale();

        public SheetExtensionPage()
        {
            InitializeComponent();
        }

        public void SetFilePath(string filepath)
        {
            FilePath = filepath;
        }

        protected override void OnPropertyPageInitialised(SharpPropertySheet parent)
        {
            SetFilePath(parent.SelectedItemPaths.First());
            
            MessageService.Push("SetLocale");
            MessageService.Push(MessageService.GetLocale());
            MessageService.Commit();

            ReloadPage();
        }

        protected override void OnPropertySheetApply()
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply");
            MessageService.Commit();
        }

        protected override void OnPropertySheetOK()
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK");
            MessageService.Commit();
        }

        private void OnClick_btnAdd(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd");
            MessageService.Commit();
            WinformService.GetWriterWindow().Show();
        }

        private void OnLoad_SheetExtensionPage(object sender, EventArgs e)
        {
            PageTitle = Properties.Resources.PageTitle_en;
            labelTitle.Text = Properties.Resources.labelTitle_en;
            btnAdd.Text = Properties.Resources.btnAdd_en;
            txtTerminal.Text = Properties.Resources.txtTerminal_en;

            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnLoad_SheetExtensionPage");
            MessageService.Commit();

            WinformService.SetSheetPage(this);
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
        }

        public void ReloadPage()
        {
            if (FilePath == null)
            {
                SetTxtTerminal(Properties.Resources.msgNotRecognized_en);
            }
            else
            {
                MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertyPageInitialised");
                MessageService.Push(FilePath);
                MessageService.Commit();

                string response = MessageService.Pull();
                SetTxtTerminal(response);
                txtTerminal.Enabled = true;
            }
        }
    }
}
