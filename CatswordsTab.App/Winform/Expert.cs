using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CatswordsTab.App.Winform
{
    public partial class Expert : Form
    {
        public Expert()
        {
            InitializeComponent();
        }
        
        private void OnLoad_Expert(object sender, EventArgs e)
        {
            Dictionary<string, string> _computed = WinformService.GetMainWindow().GetComputed();

            labelTitle.Text = "Expert";
            btnSubmit.Text = "Submit";
            txtExtension.Text = _computed["extension"];
            txtHashMd5.Text = _computed["md5"];
            txtHashSha1.Text = _computed["sha1"];
            txtHashCrc32.Text = _computed["crc32"];
            txtHashSha256.Text = _computed["sha256"];
            txtHashHead32.Text = _computed["head32"];
        }

        private void OnClick_btnSubmit(object sender, EventArgs e)
        {

        }
    }
}
