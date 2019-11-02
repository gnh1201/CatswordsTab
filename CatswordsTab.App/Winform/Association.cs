using CatswordsTab.App.Model;
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
    public partial class Association : Form
    {
        public Association()
        {
            InitializeComponent();
        }

        private void OnLoad_Association(object sender, EventArgs e)
        {
            Text = T._(Text);
            labelTitle.Text = T._(labelTitle.Text);
            btnOk.Text = T._(btnOk.Text);

            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "Resource Name";
            dataGridView1.Columns[1].Name = "Default";
            dataGridView1.Columns[2].Name = "Content Type";
            dataGridView1.Columns[3].Name = "Perceived Type";

            List<AssociationModel> associations = RegistryService.GetAssoiciations();
            foreach (AssociationModel item in associations)
            {
                dataGridView1.Rows.Add(new string[] { item.ResourceName, item.Default, item.ContentType, item.PerceivedType });
            }
        }

        private void OnClick_btnOk(object sender, EventArgs e)
        {
            Close();
        }
    }
}
