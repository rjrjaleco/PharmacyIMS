using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace PharmacyIMS.Windows
{
    /// <summary>
    /// Interaction logic for AddSupplierWindow.xaml
    /// </summary>
    public partial class AddSupplierWindow : Window
    {
        public AddSupplierWindow()
        {
            InitializeComponent();
        }

        private void AddSupplierBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierNameTbx.Text != "")
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("INSERT INTO [SUPPLIER] (SupplierName, SupplierAddress, SupplierDetails) VALUES (@SupplierName, @SupplierAddress, @SupplierDetails)", con);
                command.Parameters.AddWithValue("@SupplierName", SupplierNameTbx.Text);
                command.Parameters.AddWithValue("@SupplierAddress", SupplierAddressTbx.Text);
                command.Parameters.AddWithValue("@SupplierDetails", SupplierDetailsTbx.Text);
                command.ExecuteNonQuery();
                con.Close();
                DialogResult = true;
            }
            else
                MessageBox.Show("Please enter a valid name!", "Error: Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelSupplierBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
