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
    /// Interaction logic for FileReportPage.xaml
    /// </summary>
    public partial class FileReportPage : UserControl
    {
        public FileReportPage(string filename)
        {
            InitializeComponent();
            tbContent.Text = FileService.GetReport(filename);
        }
    }
}
