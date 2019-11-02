using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Welcome : Form
    {
        private string AppPathFile = AppDataService.GetFilePath("CatswordsTab.App.Path.txt");
        public string FileName { get; set; }

        public Welcome()
        {
            InitializeComponent();

            string path = GetAppPath();
            string _path = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (!path.Equals(_path))
            {
                SetAppPath(_path);
            }
        }

        private string GetAppPath()
        {
            try
            {
                return File.ReadAllText(AppPathFile);
            }
            catch (Exception)
            {
                return "";
            }
        }

        private void SetAppPath(string path)
        {
            File.WriteAllText(AppPathFile, path, Encoding.UTF8);
        }

        private void OnLoad_Welcome(object sender, EventArgs e)
        {
            Text = T._(Text);
            txtTerminal.Enabled = true;
            labelTitle.Text = T._(labelTitle.Text);
            txtTerminal.Text = T._(txtTerminal.Text);
            btnAgree.Text = T._(btnAgree.Text);
            linkLabel1.Text = T._(linkLabel1.Text);
            linkLabel2.Text = T._(linkLabel2.Text);
        }

        private void ChooseFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = T._("Choose your file...");
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileName = fd.FileName;
                WinformService.SetMainWindow(new Main(FileName));
                WinformService.GetMainWindow().ShowDialog();
            }
        }

        private void OnClick_btnAgree(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(FileName))
            {
                ChooseFile();
            }
            else
            {
                WinformService.SetMainWindow(new Main(FileName));
                WinformService.GetMainWindow().ShowDialog();
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }

    }
}
