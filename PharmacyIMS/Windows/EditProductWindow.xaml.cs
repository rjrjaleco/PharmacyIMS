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
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow()
        {
            InitializeComponent();
        }

        private void EditProductBtn_Click(object sender, RoutedEventArgs e)
        {
            decimal num1, num2;
            int num3;
            if (decimal.TryParse(SellingPriceTbx.Text, out num1) == true && decimal.TryParse(BuyingPriceTbx.Text, out num2) == true && int.TryParse(QuantityTbx.Text, out num3) == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\rjrjaleco\documents\visual studio 2015\Projects\PharmacyIMS\PharmacyIMS\Database\DatabaseTest.mdf");
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("UPDATE [PRODUCT] SET ProductName = @ProductName, GenericName = @GenericName, Type = @Type, Form = @Form, SellingPrice = @SellingPrice, BuyingPrice = @BuyingPrice, Quantity = @Quantity WHERE ID="+ViewModels.ViewModelLocator.MainWindowViewModel.SelectedProduct.ID, con);
                command.Parameters.AddWithValue("@ProductName", ProductNameTbx.Text);
                command.Parameters.AddWithValue("@GenericName", GenericNameTbx.Text);
                command.Parameters.AddWithValue("@Type", TypeTbx.Text);
                command.Parameters.AddWithValue("@Form", FormTbx.Text);
                command.Parameters.AddWithValue("@SellingPrice", SellingPriceTbx.Text);
                command.Parameters.AddWithValue("@BuyingPrice", BuyingPriceTbx.Text);
                command.Parameters.AddWithValue("@Quantity", QuantityTbx.Text);
                command.ExecuteNonQuery();
                con.Close();
                DialogResult = true;
            }
            else
                MessageBox.Show("Please enter a valid input!", "Error: Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void CancelProductBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
