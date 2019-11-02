﻿using CatswordsTab.WpfApp.Service;
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
    /// Interaction logic for Signin.xaml
    /// </summary>
    public partial class SigninPage : UserControl
    {
        public SigninPage()
        {
            InitializeComponent();
        }

        private void OnClick_btSignIn(object sender, RoutedEventArgs e)
        {

        }

        private void OnClick_btSignUp(object sender, RoutedEventArgs e)
        {
            UIService.CreateTabPage(new CatswordsTab.WpfApp.Page.SignupPage(), "Join us");
        }
    }
}
