using SharpShell.SharpPropertySheet;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CatswordsTab.Shell
{
    public partial class SheetExtensionPage : SharpPropertyPage
    {
        private string FilePath;
        private Task MessageListener;
        private bool IsStopListen = false;
        private string language = MessageService.GetLocale();

        public SheetExtensionPage()
        {
            InitializeComponent();
            InitializeMessageListener();
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

            MessageListener.Start();
        }

        protected override void OnPropertySheetApply()
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetApply");
            MessageService.Commit();
            IsStopListen = true;
        }

        protected override void OnPropertySheetOK()
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnPropertySheetOK");
            MessageService.Commit();
            IsStopListen = true;
        }

        private void Reload()
        {
            if (FilePath == null)
            {
                SetTxtTerminal(Properties.Resources.msgNotRecognized_en);

                if(language == "ko")
                {
                    SetTxtTerminal(Properties.Resources.msgNotRecognized_ko);
                }
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

        private void InitializeMessageListener()
        {
            MessageListener = new Task(() =>
            {
                Reload();

                while (!IsStopListen)
                {
                    MessageService.Push("GetMessage");
                    MessageService.Commit();
                    string response = MessageService.Pull();

                    if (response == "Reload")
                    {
                        Reload();
                    }

                    Thread.Sleep(30000);
                }
            });
        }

        private void OnClick_btnAdd(object sender, EventArgs e)
        {
            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnClick_btnAdd");
            MessageService.Commit();
        }

        private void OnLoad_SheetExtensionPage(object sender, EventArgs e)
        {
            PageTitle = Properties.Resources.PageTitle_en;

            labelTitle.Text = Properties.Resources.labelTitle_en;
            btnAdd.Text = Properties.Resources.btnAdd_en;
            txtTerminal.Text = Properties.Resources.txtTerminal_en;
            
            if (language == "ko")
            {
                PageTitle = Properties.Resources.PageTitle_ko;
                labelTitle.Text = Properties.Resources.labelTitle_ko;
                btnAdd.Text = Properties.Resources.btnAdd_ko;
                txtTerminal.Text = Properties.Resources.txtTerminal_ko;
            }

            MessageService.Push("CatswordsTab.Shell.SheetExtensionPage.OnLoad_SheetExtensionPage");
            MessageService.Commit();
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
        }
    }
}
