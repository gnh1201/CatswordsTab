using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void ChooseFile()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose your file...";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                WinformService.SetMainWindow(new Main(fd.FileName));
                WinformService.GetMainWindow().ShowDialog();
            }
        }

        private void OnClick_btnAgree(object sender, EventArgs e)
        {
            ChooseFile();
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
