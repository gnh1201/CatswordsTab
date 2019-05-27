using System;
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
            labelTitle.Text = "Expert";
            btnSubmit.Text = "Submit";
        }

        private void OnClick_btnSubmit(object sender, EventArgs e)
        {

        }
    }
}
