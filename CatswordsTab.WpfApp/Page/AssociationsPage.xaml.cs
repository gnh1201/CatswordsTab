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
    /// Interaction logic for AssociationsPage.xaml
    /// </summary>
    public partial class AssociationsPage : UserControl
    {
        public class DataModel
        {
            public string ResourceName { get; set; }
            public string Default { get; set; }
            public string ContentType { get; set; }
            public string PerceivedType { get; set; }
        }

        public AssociationsPage()
        {
            InitializeComponent();

            List<DataModel> items = new List<DataModel>();
            List<AssociationModel> assocs = RegistryService.GetAssoiciations();
            foreach(AssociationModel assoc in assocs)
            {
                items.Add(new DataModel
                {
                    ResourceName = assoc.ResourceName,
                    Default = assoc.Default,
                    ContentType = assoc.ContentType,
                    PerceivedType = assoc.PerceivedType
                });
            }
            dg1.ItemsSource = items;
        }
    }
}
