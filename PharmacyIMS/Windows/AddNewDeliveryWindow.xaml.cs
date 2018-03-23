using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PharmacyIMS.Windows
{
    /// <summary>
    /// Interaction logic for AddNewDeliveryWindow.xaml
    /// </summary>
    public partial class AddNewDeliveryWindow : Window
    {
        public AddNewDeliveryWindow()
        {
            InitializeComponent();
            SupplierCmb.DataContext = ViewModels.ViewModelLocator.MainWindowViewModel;
            OrderDateDtp.SelectedDate = DateTime.Now;
            var arrivedate = DateTime.Now;
            ArrivalDateDtp.SelectedDate = arrivedate.AddDays(1);
        }

        private void AddDeliveryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierCmb.SelectedItem != null)
            {
                var supplier = SupplierCmb.SelectedItem as Classes.SUPPLIER;
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("INSERT INTO [DELIVERY] (OrderDate, ArrivalDate, DriverName, SupplierID) VALUES (@OrderDate, @ArrivalDate, @DriverName, @SupplierID)", con);
                command.Parameters.AddWithValue("@OrderDate", OrderDateDtp.SelectedDate);
                command.Parameters.AddWithValue("@ArrivalDate", ArrivalDateDtp.SelectedDate);
                command.Parameters.AddWithValue("@DriverName", DriverTbx.Text);
                command.Parameters.AddWithValue("@SupplierID", supplier.ID);
                command.ExecuteNonQuery();
                con.Close();
                DialogResult = true;
            }
            else
                MessageBox.Show("Please select a supplier!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelDeliveryBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
