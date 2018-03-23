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
using System.Data.SqlClient;

namespace PharmacyIMS.Windows
{
    /// <summary>
    /// Interaction logic for AddProductToSupplierWindow.xaml
    /// </summary>
    public partial class AddProductToSupplierWindow : Window
    {
        public AddProductToSupplierWindow()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            bool duplicate = false;
            if (ProductListView.SelectedItem != null)
            {
                var prod = ProductListView.SelectedItem as Classes.PRODUCT;
                for (int x = 0; x < ViewModels.ViewModelLocator.MainWindowViewModel.SelectedSupplier.SupplierProductList.Count; x++)
                {
                    if (ViewModels.ViewModelLocator.MainWindowViewModel.SelectedSupplier.SupplierProductList[x].ID == prod.ID)
                    {
                        duplicate = true;
                    }
                }
                if (duplicate == false)
                {
                    var holder = ProductListView.SelectedItem as Classes.PRODUCT;
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("INSERT INTO [SUPPLIER_PRODUCT] (SupplierID, ProductID) VALUES (@SupplierID, @ProductID)", con);
                    command.Parameters.AddWithValue("@SupplierID", SelectedSupplierIDTblk.Text);
                    command.Parameters.AddWithValue("@ProductID", holder.ID);
                    command.ExecuteNonQuery();
                    con.Close();
                    DialogResult = true;
                }
                else
                    MessageBox.Show("The selected supplier has already the selected product!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Please select a product to add!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
