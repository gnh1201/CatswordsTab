using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace CatswordsTab.WpfApp.Page
{
    /// <summary>
    /// Interaction logic for ReputationPage.xaml
    /// </summary>
    public partial class ReputationsPage : UserControl
    {
        public class DataItem
        {
            public string CreatedOn { get; set; }
            public string Message { get; set; }
        }

        private class DataModel
        {
            public bool Success { get; set; }
            public List<DataItem> Data { get; set; }
        }

        private string _Text = "Write your comment...";

        public ReputationsPage()
        {
            InitializeComponent();

            // set placeholder
            tbComment.Text = _Text;
            tbComment.Foreground = Brushes.Gray;

            var client = new RestClient("https://catswords.re.kr/ep/?route=api.tab.json");
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            try
            {
                JsonDeserializer deserial = new JsonDeserializer();
                DataModel dataModel = deserial.Deserialize<DataModel>(response);
                List<DataItem> items = dataModel.Data;
                dg1.ItemsSource = items;
            }
            catch(Exception) { }
        }

        private void OnGotFocus_tbComment(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tbComment.Text != "")
            {
                tbComment.Text = "";
                tbComment.Foreground = Brushes.Black;
            }
        }

        private void OnLostFocus_tbComment(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tbComment.Text == "")
            {
                tbComment.Text = _Text;
                tbComment.Foreground = Brushes.Gray;
            }
        }

    }
}
