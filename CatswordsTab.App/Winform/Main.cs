using System;
using System.Threading;
using System.Windows.Forms;

namespace CatswordsTab.App
{
    public partial class Main : Form
    {
        private string _path;

        public Main()
        {
            ChooseTargetFile();
            InitializeComponent();
        }

        private void ChooseTargetFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Open Target File";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                _path = fd.FileName;
            }
            else
            {
                ChooseTargetFile();
            }
        }

        private void SetPath(string path)
        {
            _path = path;
        }

        private void OnClick_btnWriter(object sender, EventArgs e)
        {
            WinformService.GetWriterWindow().Show();
        }

        private void OnLoad_Main(object sender, EventArgs e)
        {
            labelTitle.Text = Properties.Resources.labelTitle_en;
            btnWriter.Text = Properties.Resources.btnWriter_en;
            txtTerminal.Text = Properties.Resources.txtTerminal_en;
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
        }
    }
}
