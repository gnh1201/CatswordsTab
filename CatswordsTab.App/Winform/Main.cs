using CatswordsTab.App.Model;
using LiteDB;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatswordsTab.App
{
    public partial class Main : Form
    {
        private string _path;
        private ComputationModel  _computed;
        private string _result = T._("Loading...");

        public Main(string _path)
        {
            InitializeComponent();
            WinformService.SetMainWindow(this);
            SetPath(_path);
            ReloadResult();
        }

        private void SetResult()
        {
            _computed = ComputeService.Compute(_path);
            _result = MainService.GetResult(_path);
        }

        private void OnClick_btnWriter(object sender, EventArgs e)
        {
            WinformService.GetWriterWindow().Show();
        }

        private void OnLoad_Main(object sender, EventArgs e)
        {
            this.Text = T._(this.Text);
            labelTitle.Text = T._(labelTitle.Text);
            btnWriter.Text = T._(btnWriter.Text);
            linkLabel2.Text = T._(linkLabel2.Text);
            tabPage1.Text = T._(tabPage1.Text);
            tabPage2.Text = T._(tabPage2.Text);

            // Gex HEX data (limit 8K)
            textBox1.Text = ComputeService.GetHexView(ComputeService.GetFileBytes(_path, 8192));
        }

        private void OnKeyDown_Main(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        public void SetPath(string path)
        {
            _path = path;
        }

        public string GetPath()
        {
            return _path;
        }

        public void SetTxtTerminal(string text)
        {
            txtTerminal.Text = text;
            txtTerminal.Enabled = true;
        }

        public ComputationModel GetComputed()
        {
            return _computed;
        }

        public string GetResult()
        {
            return _result;
        }

        public void ReloadResult()
        {
            SetResult();
            SetTxtTerminal(GetResult());
        }

        private void OnClick_linkLabel1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }

        private void OnClick_linkLabel2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/catswords/CatswordsTab");
        }

        private void OnClick_LabelTitle(object sender, EventArgs e)
        {
            WinformService.GetExpertWindow().Show();
        }
    }
}
