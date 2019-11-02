using CatswordsTab.WpfApp.Model;
using CatswordsTab.WpfApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CatswordsTab.WpfApp.Page
{
    /// <summary>
    /// Interaction logic for Applications.xaml
    /// </summary>
    public partial class ApplicationsPage : UserControl
    {
        public class DataModel
        {
            public string InstallDate { get; set; }
            public string Publisher { get; set; }
            public string DisplayName { get; set; }
            public string DisplayVersion { get; set; }
        }

        public ApplicationsPage()
        {
            InitializeComponent();

            List<DataModel> items = new List<DataModel>();
            List<ApplicationModel> apps = RegistryService.GetInstalledApps();
            foreach (ApplicationModel app in apps)
            {
                string displayName = app.DisplayName;
                if (string.IsNullOrEmpty(displayName))
                {
                    displayName = "(Unknown or Uninstalled)";
                }
                items.Add(new DataModel
                {
                    InstallDate = app.InstallDate,
                    Publisher = app.Publisher,
                    DisplayName = displayName,
                    DisplayVersion = app.DisplayVersion
                });
            }
            dg1.ItemsSource = items;
        }
    }
}
