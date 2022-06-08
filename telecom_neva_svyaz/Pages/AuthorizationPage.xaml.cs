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

namespace telecom_neva_svyaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void btSignInUser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServicesListPage());
        }

        private void btSignInAdmin(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Text.Contains("2222")) {
                NavigationService.Navigate(new AdminServicesListPage());
            } else
            {
                MessageBox.Show("Неверный пароль, попробуй вот так: 2222");
            }
        }
    }
}
