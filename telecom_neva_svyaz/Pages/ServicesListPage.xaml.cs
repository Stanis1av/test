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
using telecom_neva_svyaz.Database;

namespace telecom_neva_svyaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesListPage.xaml
    /// </summary>
    public partial class ServicesListPage : Page
    {
        const int NumInPage = 5;

        int PageNum = 0;
        public ServicesListPage()
        {
            InitializeComponent();

            FilterServices.Items.Add("Все");
            FilterServices.Items.Add("Визит мастера");
            FilterServices.Items.Add("Удаленное подключение");

            FilterServices.SelectedIndex = 0;

            SortServices.Items.Add("▲ Наименование");
            SortServices.Items.Add("▼ Наименование");
            SortServices.Items.Add("▲ Время выполнения");
            SortServices.Items.Add("▼ Время выполнения");
            SortServices.Items.Add("▲ По типу работы");
            SortServices.Items.Add("▼ По типу работы");

            SortServices.SelectedIndex = 0;

            UpdateData();

        }
        private void UpdateData()
        {
            IEnumerable<Service> services = EfModel.Init().Services
                .Where(p => p.ServiceName.Contains(SearchServices.Text) || p.ServiceDescription.Contains(SearchServices.Text));

            switch (SortServices.SelectedIndex)
            {
                case 0:
                    services = services.OrderBy(s => s.ServiceName);
                    break;
                case 1:
                    services = services.OrderByDescending(s => s.ServiceName);
                    break;
                case 2:
                    services = services.OrderBy(s => s.ServiceDurationInMunutes);
                    break;
                case 3:
                    services = services.OrderByDescending(s => s.ServiceDurationInMunutes);
                    break;
                case 4:
                    services = services.OrderBy(s => s.ServiceIsVisit);
                    break;
                case 5:
                    services = services.OrderByDescending(s => s.ServiceIsVisit);
                    break;
            }
            switch (FilterServices.SelectedIndex)
            {
                case 1:
                    services = services.Where(s => s.ServiceIsVisit == 1);
                    break;
                case 2:
                    services = services.Where(s => s.ServiceIsVisit == 0);
                    break;
            }

            LVServices.ItemsSource = services.Skip(NumInPage * PageNum).Take(NumInPage).ToList();
            LVServices.SelectedItems.Clear();

            StackPages.Children.Clear();

            int PageCount = (services.Count() - 1) / NumInPage + 1;

            for (int i = 0; i < PageCount; i++)
            {
                Button button = new Button { Content = new TextBlock { Text = (i + 1).ToString() }, Tag = i };

                button.Click += PageClick;

                if (i == PageNum)

                    (button.Content as TextBlock).TextDecorations = TextDecorations.Underline;

                StackPages.Children.Add(button);
            }

            BackPage.Visibility = Visibility.Visible;
            NextPage.Visibility = Visibility.Visible;

            if (PageNum == 0)
                BackPage.Visibility = Visibility.Collapsed;

            if (PageNum >= PageCount - 1)
                NextPage.Visibility = Visibility.Collapsed;
        }

        private void BtAddOrderService(object sender, RoutedEventArgs e)
        {
            Service service = (sender as Button).DataContext as Service;
            NavigationService.Navigate(new OrderServicePage(service));
        }

        private void SearchChange(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void SortChange(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void PageClick(object sender, RoutedEventArgs e)
        {
            PageNum = Convert.ToInt32((sender as Button).Tag);
            UpdateData();
        }

        private void BackPageClick(object sender, RoutedEventArgs e)
        {
            PageNum--;

            UpdateData();
        }

        private void NextPageClick(object sender, RoutedEventArgs e)
        {
            PageNum++;

            UpdateData();
        }
    }
}
