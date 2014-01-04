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
using System.Windows.Shapes;

namespace ProjectMvvm.view
{
    /// <summary>
    /// Interaction logic for Contact.xaml
    /// </summary>
    public partial class Contact : Window
    {
        public Contact()
        {
            InitializeComponent();
            txtCompany.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtJobRole.IsEnabled = false;
            txtMobile.IsEnabled = false;
            txtName.IsEnabled = false;
            txtPhone.IsEnabled = false;

            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtCompany.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtJobRole.IsEnabled = true;
            txtMobile.IsEnabled = true;
            txtName.IsEnabled = true;
            txtPhone.IsEnabled = true;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCompany.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtJobRole.IsEnabled = false;
            txtMobile.IsEnabled = false;
            txtName.IsEnabled = false;
            txtPhone.IsEnabled = false;
        }
    }
}
