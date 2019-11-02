using CatswordsTab.WpfApp.Page;
using CatswordsTab.WpfApp.Service;
using System.Windows;
using System.Windows.Controls;

namespace CatswordsTab.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            UIService.TabControlInstance = tcMain;
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SigninPage(), "Sign in");
        }

        private void Button_Applications_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.ApplicationsPage(), "Applications");
        }

        private void Button_Associations_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.AssociationsPage(), "Associations");
        }

        private void Button_Downloads_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.DownloadsPage(), "Downloads");
        }

        private void Button_Activity_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SigninPage(), "Sign in");
        }

        private void Button_Talk_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SigninPage(), "Sign in");
        }

        private void Button_Papers_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SigninPage(), "Sign in");
        }

        private void Button_Info_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SigninPage(), "Sign in");
        }

        private void Button_Reputations_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.ReputationsPage(), "Reputations");
        }

        private void Button_Browse_Clicked(object sender, RoutedEventArgs e)
        {
            string filename = FileService.ChooseFile();
            if(filename != null)
            {
                FileReportPage page = new FileReportPage(filename);
                UIService.CreateTabPage(page, "File Report");
            }
        }

        private void Button_Fonts_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.FontsPage(), "FontFamily");
        }

        private void Button_Kakao_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SocialPage("https://discord.gg/359930650330923008"), "Kakao");
        }

        private void Button_Discord_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SocialPage("https://pf.kakao.com/_mNxisj"), "Kakao");
        }

        private void Button_Web_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SocialPage("https://exts.kr"), "Web");
        }

        private void Button_Decryptor_Clicked(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.DecryptorPage(), "Decryptor");
        }
    }
}
