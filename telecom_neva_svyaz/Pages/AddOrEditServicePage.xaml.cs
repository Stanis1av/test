using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
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
    /// Логика взаимодействия для AddOrEditServicePage.xaml
    /// </summary>
    public partial class AddOrEditServicePage : Page
    {
        Service Service;
        Service service = new Service();
        public AddOrEditServicePage(Service service)
        {
            Service = EfModel.Init().Services.Find(service.ServiceId);
            InitializeComponent();
            DataContext = Service;
        }
        /// <summary>
        /// Изменение картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageChangeClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "All Files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                Service.ServicePhoto = File.ReadAllBytes(openFile.FileName);

            }
        }
        
        private void BtImageAdd(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "All Files|*.*" };
            if (openFile.ShowDialog() == true)
            {
                Service.ServicePhoto = File.ReadAllBytes(openFile.FileName);

            }
        }
        /// <summary>
        /// Удаление допнительной картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void BtSaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Service.ServiceId == 0)
                    EfModel.Init().Services.Add(Service);
                EfModel.Init().SaveChanges();
                MessageBox.Show("Добавление прошло успешно");
            }
            catch (DbEntityValidationException ex)
            {
                MessageBox.Show(String.Join(", ", ex.EntityValidationErrors.Last().ValidationErrors.Select(ve => ve.ErrorMessage)));
            }
        }
    }
}
