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
    /// Interaction logic for EditSupplierWindow.xaml
    /// </summary>
    public partial class EditSupplierWindow : Window
    {
        public EditSupplierWindow()
        {
            InitializeComponent();
        }

        private void CancelSupplierBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void EditSupplierBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierNameTbx.Text != "")
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("UPDATE [SUPPLIER] SET SupplierName = @SupplierName, SupplierAddress = @SupplierAddress, SupplierDetails = @SupplierDetails WHERE ID=" + ViewModels.ViewModelLocator.MainWindowViewModel.SelectedSupplier.ID, con);
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
    }
}
