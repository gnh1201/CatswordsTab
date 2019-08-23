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
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
        }

        private void OnLoad_Application(object sender, EventArgs e)
        {
            Text = T._(Text);
            labelTitle.Text = T._(labelTitle.Text);
            btnOk.Text = T._(btnOk.Text);

            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "Installed Date";
            dataGridView1.Columns[1].Name = "Author";
            dataGridView1.Columns[2].Name = "Name";
            dataGridView1.Columns[3].Name = "Version";

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            List<ApplicationModel> apps = RegistryService.GetInstalledApps();
            foreach (ApplicationModel app in apps)
            {
                dataGridView1.Rows.Add(new string[] { app.InstallDate, app.Publisher, app.DisplayName, app.DisplayVersion });
            }
        }

        private void OnClick_btnOk(object sender, EventArgs e)
        {
            Close();
        }
    }
}
