using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для OrderServicePage.xaml
    /// </summary>
    public partial class OrderServicePage : Page
    {
        Request request;
        public OrderServicePage(Service service)
        {
            request = new Request { Service = service };
            InitializeComponent();
            DataContext = request;
            CbClients.ItemsSource = EfModel.Init().Clients.ToList();
            CbStaffs.ItemsSource = EfModel.Init().Staffs.ToList();
            CbRequestType.ItemsSource = EfModel.Init().RequestTypes.ToList();
        }

        private void OrderClick(object sender, RoutedEventArgs e)
        {
            try
            {
                request.Client = CbClients.SelectedItem as Client;
                request.Staff = CbStaffs.SelectedItem as Staff;
                request.RequestType1 = CbRequestType.SelectedItem as RequestType;
                EfModel.Init().Requests.Add(request);
                EfModel.Init().SaveChanges();
                MessageBox.Show("Запись прошла успешно!");

            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(string.Join(",", ex.EntityValidationErrors.Last().ValidationErrors.Select(v => v.ErrorMessage)));
            }
        }

    }
}
