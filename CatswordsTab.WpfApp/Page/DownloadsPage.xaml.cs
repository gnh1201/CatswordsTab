using CatswordsTab.WpfApp.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CatswordsTab.WpfApp.Page
{
    /// <summary>
    /// Interaction logic for DownloadsPage.xaml
    /// </summary>
    public partial class DownloadsPage : UserControl
    {
        private string downloadsPath = KnownFolderService.GetPath(KnownFolder.Downloads);

        public class DataModel
        {
            public DateTime CreationTime { get; set; }
            public string FileName { get; set; }
            public string FileType { get; set; }
        }

        public DownloadsPage()
        {
            InitializeComponent();

            // https://stackoverflow.com/a/14877330
            List<DataModel> items = new List<DataModel>();
            FileInfo[] Files = FileService.GetFiles(downloadsPath);
            foreach (FileInfo file in Files)
            {
                items.Add(new DataModel
                {
                    CreationTime = file.CreationTime,
                    FileName = file.Name,
                    FileType = MIMETypeService.GetContentType(file.FullName)
                });
            }
            dg1.ItemsSource = items;
        }

        private void OnClick_View_Properties(object sender, System.Windows.RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var data = (DataModel)item.SelectedCells[0].Item;

            MessageBox.Show(FileService.GetDetails(Path.Combine(downloadsPath, data.FileName)));
        }
    }
}
