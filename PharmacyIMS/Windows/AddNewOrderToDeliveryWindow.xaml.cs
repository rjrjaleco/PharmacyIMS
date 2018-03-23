using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PharmacyIMS.Windows
{
    /// <summary>
    /// Interaction logic for AddNewOrderToDeliveryWindow.xaml
    /// </summary>
    public partial class AddNewOrderToDeliveryWindow : Window
    {
        int value, holderID, holderQuantity, pos;
        bool duplicate = false;
        public AddNewOrderToDeliveryWindow()
        {
            InitializeComponent();
            //SupplierProductListView.ItemsSource = ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.SupplierDelivery.SupplierProductList;
        }

        private void AddProductOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SupplierProductListView.SelectedItem != null)
            {
                if(QuantityTbx.Text!="")
                {
                    if(int.TryParse(QuantityTbx.Text,out value) != false)
                    {
                        for(int x=0; x<ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList.Count; x++)
                        {
                            if(SupplierProductListView.SelectedItem == ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList[x].OrderProduct)
                            {
                                duplicate = true;
                                pos = x;
                                holderID = ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList[x].ID;
                                holderQuantity = ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList[x].Quantity;
                            }
                        }
                        if (duplicate == false)
                        {
                            var holder = SupplierProductListView.SelectedItem as Classes.PRODUCT;
                            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                            con.Open();
                            SqlCommand command = new SqlCommand();
                            command = new SqlCommand("INSERT INTO [ORDER] (Quantity, ProductID) OUTPUT INSERTED.ID VALUES (@Quantity, @ProductID)", con);
                            command.Parameters.AddWithValue("@Quantity", QuantityTbx.Text);
                            command.Parameters.AddWithValue("@ProductID", holder.ID);
                            int orderID = (int)command.ExecuteScalar();

                            SqlCommand command1 = new SqlCommand();
                            command1 = new SqlCommand("INSERT INTO [DELIVERY_ORDER] (OrderID, DeliveryID) OUTPUT INSERTED.ID VALUES (@OrderID, @DeliveryID)", con);
                            command1.Parameters.AddWithValue("@DeliveryID", ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.ID);
                            command1.Parameters.AddWithValue("@OrderID", orderID);
                            command1.ExecuteNonQuery();
                            con.Close();

                            var newOrder = new Classes.ORDER();
                            newOrder.Quantity = Convert.ToInt16(QuantityTbx.Text);
                            newOrder.OrderProduct = holder;
                            ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList.Add(newOrder);
                        }
                        else
                        {
                            var result = MessageBox.Show("Delivery already contains selected product. Do you want to overwrite the existing value?" + Environment.NewLine + "" + Environment.NewLine + "YES - Overwrites existing quantity" + Environment.NewLine + "NO - Adds existing quantity to new input" + Environment.NewLine + "CANCEL - No action", "Error", MessageBoxButton.YesNoCancel, MessageBoxImage.Error);
                            if (result == MessageBoxResult.Yes)
                            {
                                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                                con.Open();
                                SqlCommand command = new SqlCommand();
                                command = new SqlCommand("UPDATE [ORDER] SET Quantity = @Quantity WHERE ID=" + holderID, con);
                                command.Parameters.AddWithValue("@Quantity", QuantityTbx.Text);
                                command.ExecuteNonQuery();
                                con.Close();
                                ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList[pos].Quantity = Convert.ToInt16(QuantityTbx.Text);
                            }
                            if(result ==MessageBoxResult.No)
                            {
                                var temp1 = Convert.ToInt16(QuantityTbx.Text) + holderQuantity;
                                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                                con.Open();
                                SqlCommand command = new SqlCommand();
                                command = new SqlCommand("UPDATE [ORDER] SET Quantity = @Quantity WHERE ID=" + holderID, con);
                                command.Parameters.AddWithValue("@Quantity", temp1.ToString());
                                command.ExecuteNonQuery();
                                con.Close();
                                ViewModels.ViewModelLocator.MainWindowViewModel.SelectedDelivery.DeliveryOrderList[pos].Quantity = temp1;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Please input a VALID quantity to order", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Please input a quantity to order", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                MessageBox.Show("Please select a product to order", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            QuantityTbx.Text = "";
            UpdateDeliveryOrders();
        }
        private void UpdateDeliveryOrders()
        {
            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * From [DELIVERY_ORDER]", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * From [DELIVERY]", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT * From [ORDER]", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            con.Open();

            for (int a = 0; a < ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList.Count; a++)
            {
                var holderDelivery = ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList[a] as Classes.DELIVERY;
                holderDelivery.DeliveryOrderList.Clear();
            }
            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                for (int y = 0; y < ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList.Count; y++)
                {
                    var holderDelivery = ViewModels.ViewModelLocator.MainWindowViewModel.DeliveryList[y] as Classes.DELIVERY;
                    if (dt1.Rows[x]["DeliveryID"].ToString() == holderDelivery.ID.ToString())
                    {
                        for (int z = 0; z < ViewModels.ViewModelLocator.MainWindowViewModel.OrderList.Count; z++)
                        {
                            var holderOrder = ViewModels.ViewModelLocator.MainWindowViewModel.OrderList[z] as Classes.ORDER;
                            if (dt1.Rows[x]["OrderID"].ToString() == holderOrder.ID.ToString())
                            {
                                holderDelivery.DeliveryOrderList.Add(holderOrder);
                            }
                        }
                    }
                }
            }
            con.Close();
        }
    }
}
