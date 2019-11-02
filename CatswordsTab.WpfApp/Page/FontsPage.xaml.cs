using CatswordsTab.WpfApp.Model;
using CatswordsTab.WpfApp.Service;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CatswordsTab.WpfApp.Page
{
    /// <summary>
    /// Interaction logic for FontsPage.xaml
    /// </summary>
    public partial class FontsPage : UserControl
    {
        public FontsPage()
        {
            InitializeComponent();

            List<FontModel> items = EnvironmentService.GetInstalledFonts();
            dg1.ItemsSource = items;
        }
    }
}
