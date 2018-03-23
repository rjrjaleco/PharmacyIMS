using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;


namespace PharmacyIMS.ViewModels
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            _productview = CollectionViewSource.GetDefaultView(ProductList);
            _supplierview = CollectionViewSource.GetDefaultView(SupplierList);
            _deliveryview = CollectionViewSource.GetDefaultView(DeliveryList);
        }
        #region PRODUCT
        private ICollectionView _productview;
        public Classes.PRODUCT SelectedProduct { get; set; }

        ObservableCollection<Classes.PRODUCT> _productList = new ObservableCollection<Classes.PRODUCT>();
        public ObservableCollection<Classes.PRODUCT> ProductList { get { return _productList; } }

        public void AddProduct()
        {
            var window = new Windows.AddProductWindow();
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var newProduct = new Classes.PRODUCT();
            window.DataContext = newProduct;

            var result = window.ShowDialog();
            if (result == true)
            {
                _productList.Add(newProduct);
            }
        }

        public void EditProduct()
        {
            if (SelectedProduct != null)
            {
                var window = new Windows.EditProductWindow();
                window.Owner = Application.Current.MainWindow;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var selectedProduct = new Classes.PRODUCT();

                selectedProduct.ID = SelectedProduct.ID;
                selectedProduct.ProductName = SelectedProduct.ProductName;
                selectedProduct.GenericName = SelectedProduct.GenericName;
                selectedProduct.Type = SelectedProduct.Type;
                selectedProduct.Form = SelectedProduct.Form;
                selectedProduct.BuyingPrice = SelectedProduct.BuyingPrice;
                selectedProduct.SellingPrice = SelectedProduct.SellingPrice;
                selectedProduct.Quantity = SelectedProduct.Quantity;

                window.DataContext = selectedProduct;
                var result = window.ShowDialog();
            }
            else
                MessageBox.Show("Please select a product to edit!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void RemoveProduct()
        {
            if (SelectedProduct != null)
            {
                var result = MessageBox.Show("Proceed with deleting selected product?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("DELETE FROM [PRODUCT] WHERE ID=" + SelectedProduct.ID, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please select a product to delete", "Error: No selected product", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void ClearProducts()
        {
            var result = MessageBox.Show("Proceed with deleting all products?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("DELETE FROM [PRODUCT]", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        #region Filtering
        private string _productSearchText;
        public string ProductSearchText
        {
            get { return _productSearchText; }
            set
            {
                _productSearchText = value;
                _productview.Filter = FilterProduct;
            }
        }
        private bool FilterProduct(object o)
        {
            var item = o as Classes.PRODUCT;
            if (item == null)
            {
                return false;
            }
            return (item.ID.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.ProductName.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.GenericName.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.Type.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.Form.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.BuyingPrice.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.SellingPrice.ToString().ToLower().Contains(ProductSearchText.ToLower()) ||
                item.Quantity.ToString().ToLower().Contains(ProductSearchText.ToLower()));
        }

        #endregion

        #endregion

        #region SUPPLIER
        private ICollectionView _supplierview;
        private ICollectionView _supplierproductview;
        public Classes.SUPPLIER SelectedSupplier { get; set; }
        public Classes.PRODUCT SelectedSupplierProduct { get; set; }


        ObservableCollection<Classes.SUPPLIER> _supplierList = new ObservableCollection<Classes.SUPPLIER>();
        public ObservableCollection<Classes.SUPPLIER> SupplierList { get { return _supplierList; } }

        public void AddSupplier()
        {
            var window = new Windows.AddSupplierWindow();
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var newSupplier = new Classes.SUPPLIER();
            window.DataContext = newSupplier;

            var result = window.ShowDialog();
            if (result == true)
            {
                _supplierList.Add(newSupplier);
            }
        }

        public void EditSupplier()
        {
            if (SelectedSupplier != null)
            {
                var window = new Windows.EditSupplierWindow();
                window.Owner = Application.Current.MainWindow;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                var selectedSupplier = new Classes.SUPPLIER();

                selectedSupplier.ID = SelectedSupplier.ID;
                selectedSupplier.SupplierName = SelectedSupplier.SupplierName;
                selectedSupplier.SupplierAddress = SelectedSupplier.SupplierAddress;
                selectedSupplier.SupplierDetails = SelectedSupplier.SupplierDetails;

                window.DataContext = selectedSupplier;
                var result = window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a supplier to edit!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void RemoveSupplier()
        {
            if (SelectedSupplier != null)
            {
                var result = MessageBox.Show("Proceed with deleting selected supplier?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("DELETE FROM [SUPPLIER] WHERE ID=" + SelectedSupplier.ID, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please select a supplier to delete", "Error: No selected supplier", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void ClearSuppliers()
        {
            var result = MessageBox.Show("Proceed with deleting all suppliers?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("DELETE FROM [SUPPLIER]", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        public void AddProductToSupplier()
        {
            if (SelectedSupplier != null)
            {
                var window = new Windows.AddProductToSupplierWindow();
                window.Owner = Application.Current.MainWindow;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                window.DataContext = ViewModelLocator.MainWindowViewModel;

                var result = window.ShowDialog();
                if (result == true)
                {
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to add a product!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void RemoveSupplierProduct()
        {
            if (SelectedSupplier != null)
            {
                var result = MessageBox.Show("Proceed with deleting selected supplier product?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("DELETE FROM [SUPPLIER_PRODUCT] WHERE ProductID=" + SelectedSupplierProduct.ID + " AND SupplierID=" + SelectedSupplier.ID, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please select a supplier to delete", "Error: No selected supplier", MessageBoxButton.OK, MessageBoxImage.Asterisk);

        }
        public void ClearSupplierProduct()
        {
            var result = MessageBox.Show("Proceed with deleting all selected supplier product?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("DELETE FROM [SUPPLIER_PRODUCT] WHERE SupplierID=" + SelectedSupplier.ID, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        #region Filtering
        private string _supplierProductSearchText;
        public string SupplierProductSearchText
        {
            get { return _supplierProductSearchText; }
            set
            {
                if (SelectedSupplier != null)
                {
                    _supplierproductview = CollectionViewSource.GetDefaultView(SelectedSupplier.SupplierProductList);
                    _supplierProductSearchText = value;
                    _supplierproductview.Filter = FilterSupplierProduct;
                }
            }
        }
        private bool FilterSupplierProduct(object o)
        {
            var item = o as Classes.PRODUCT;
            if (item == null)
            {
                return false;
            }
            return (item.ID.ToString().ToLower().Contains(SupplierProductSearchText.ToLower()) ||
                item.GenericName.ToString().ToLower().Contains(SupplierProductSearchText.ToLower()) ||
                item.ProductName.ToString().ToLower().Contains(SupplierProductSearchText.ToLower()));
        }

        private string _supplierSearchText;
        public string SupplierSearchText
        {
            get { return _supplierSearchText; }
            set
            {
                _supplierSearchText = value;
                _supplierview.Filter = FilterSupplier;
            }
        }
        private bool FilterSupplier(object o)
        {
            var item = o as Classes.SUPPLIER;
            if (item == null)
            {
                return false;
            }
            return (item.ID.ToString().ToLower().Contains(SupplierSearchText.ToLower()) ||
                item.SupplierName.ToString().ToLower().Contains(SupplierSearchText.ToLower()) ||
                item.SupplierAddress.ToString().ToLower().Contains(SupplierSearchText.ToLower()) ||
                item.SupplierDetails.ToString().ToLower().Contains(SupplierSearchText.ToLower()));
        }
        #endregion
        #endregion

        #region USER
        private ICollectionView _userview;
        public Classes.USER SelectedUser { get; set; }

        ObservableCollection<Classes.USER> _userList = new ObservableCollection<Classes.USER>();
        public ObservableCollection<Classes.USER> UserList { get { return _userList; } }

        public void AddUser()
        {
            var window = new Windows.AddUserWindow();
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var newUser = new Classes.USER();
            window.DataContext = newUser;

            var result = window.ShowDialog();
            if (result == true)
            {
                _userList.Add(newUser);
            }
        }
        public void EditUser()
        {
            var window = new Windows.EditUserWindow();
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            
            window.DataContext = ViewModels.ViewModelLocator.LogInWindowViewModel.SelectedUser;

            var result = window.ShowDialog();
        }
        public void RemoveUser()
        {
            if (SelectedUser != null)
            {
                var result = MessageBox.Show("Proceed with deleting selected user?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("DELETE FROM [USER] WHERE ID=" + SelectedUser.ID, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please select a user to delete", "Error: No selected user", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void ClearUsers()
        {
            var result = MessageBox.Show("Proceed with deleting all users?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("DELETE FROM [USER]", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        #region Filtering
        private string _userSearchText;
        public string UserSearchText
        {
            get { return _userSearchText; }
            set
            {
                _userSearchText = value;
                _userview.Filter = FilterUser;
            }
        }
        private bool FilterUser(object o)
        {
            var item = o as Classes.USER;
            if (item == null)
            {
                return false;
            }
            return (item.ID.ToString().ToLower().Contains(SupplierSearchText.ToLower()) ||
                item.Username.ToString().ToLower().Contains(SupplierSearchText.ToLower()) ||
                item.Level.ToString().ToLower().Contains(SupplierSearchText.ToLower()));
        }
        #endregion
        #endregion

        #region DELIVERY
        private ICollectionView _deliveryview;
        private ICollectionView _deliveryorderview;
        public Classes.DELIVERY SelectedDelivery { get; set; }
        public Classes.ORDER SelectedDeliveryOrder { get; set; }

        ObservableCollection<Classes.DELIVERY> _deliveryList = new ObservableCollection<Classes.DELIVERY>();
        public ObservableCollection<Classes.DELIVERY> DeliveryList { get { return _deliveryList; } }

        public void AddDelivery()
        {
            var window = new Windows.AddNewDeliveryWindow();
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var newDelivery = new Classes.DELIVERY();
            window.DataContext = newDelivery;
            newDelivery.OrderDate = DateTime.Now;
            newDelivery.ArrivalDate = DateTime.Now.AddDays(1);

            var result = window.ShowDialog();
            if (result == true)
            {
                _deliveryList.Add(newDelivery);
            }
        }
        public void RemoveDelivery()
        {
            if (SelectedDelivery != null)
            {
                var result = MessageBox.Show("Proceed with deleting selected delivery?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("DELETE FROM [DELIVERY] WHERE ID=" + SelectedDelivery.ID, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please select a delivery to delete", "Error: No selected supplier", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
        public void ClearDeliveries()
        {
            var result = MessageBox.Show("Proceed with deleting all deliveries?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("DELETE FROM [DELIVERY]", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        public void ConfirmDelivery()
        {
            if(SelectedDelivery!=null)
            {
                for(int x= 0; x<SelectedDelivery.DeliveryOrderList.Count; x++)
                {
                    var order = SelectedDelivery.DeliveryOrderList[x] as Classes.ORDER;
                    for(int y=0; y<ProductList.Count;y++)
                    {
                        if(ProductList[y]==order.OrderProduct)
                        {
                            SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter();
                            SqlCommand command = new SqlCommand();
                            command = new SqlCommand("UPDATE [PRODUCT] SET Quantity = @Quantity WHERE ID=" + order.OrderProduct.ID, con);
                            command.Parameters.AddWithValue("@Quantity", Convert.ToString(ProductList[y].Quantity+order.Quantity));
                            command.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
                SqlConnection con1 = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con1.Open();
                SqlCommand command1 = new SqlCommand();
                command1 = new SqlCommand("DELETE FROM [DELIVERY] WHERE ID=" + SelectedDelivery.ID, con1);
                command1.ExecuteNonQuery();
                con1.Close();
            }
        }

        public void AddOrderToDelivery()
        {
            if (SelectedDelivery != null)
            {
                var window = new Windows.AddNewOrderToDeliveryWindow();
                window.Owner = Application.Current.MainWindow;
                window.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                //var newOrder = new Classes.ORDER();

                window.DataContext = ViewModelLocator.MainWindowViewModel;
                var result = window.ShowDialog();
                if (result == true)
                {
                }
            }
            else
                MessageBox.Show("Please select a delivery in order to add an order.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void RemoveDeliveryOrder()
        {
            if (SelectedDeliveryOrder != null)
            {
                var result = MessageBox.Show("Proceed with deleting selected order?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                    con.Open();
                    SqlCommand command = new SqlCommand();
                    command = new SqlCommand("DELETE FROM [ORDER] WHERE ID=" + SelectedDeliveryOrder.ID, con);
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
                MessageBox.Show("Please select an order to delete", "Error: No selected order", MessageBoxButton.OK, MessageBoxImage.Asterisk);

        }
        public void ClearDeliveryOrder()
        {
            var result = MessageBox.Show("Proceed with deleting all orders?", "Confirm Delete Action", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                SqlConnection con = Database.DatabaseLocator.GenerateConnection.GenerateNewConnection();
                con.Open();
                SqlCommand command = new SqlCommand();
                command = new SqlCommand("DELETE FROM [ORDER]", con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        #region Filtering
        private string _deliveryOrderSearchText;
        public string DeliveryOrderSearchText
        {
            get { return _deliveryOrderSearchText; }
            set
            {
                if (SelectedDelivery != null)
                {
                    _deliveryorderview = CollectionViewSource.GetDefaultView(SelectedDelivery.DeliveryOrderList);
                    _deliveryOrderSearchText = value;
                    _deliveryorderview.Filter = FilterDeliveryOrder;
                }
            }
        }
        private bool FilterDeliveryOrder(object o)
        {
            var item = o as Classes.ORDER;
            if (item == null)
            {
                return false;
            }
            return (item.ID.ToString().ToLower().Contains(DeliveryOrderSearchText.ToLower()) ||
                item.OrderProduct.ProductName.ToString().ToLower().Contains(DeliveryOrderSearchText.ToLower()) ||
                item.Quantity.ToString().ToLower().Contains(DeliveryOrderSearchText.ToLower()));
        }

        private string _deliverySearchText;
        public string DeliverySearchText
        {
            get { return _deliverySearchText; }
            set
            {
                _deliverySearchText = value;
                _deliveryview.Filter = FilterDelivery;
            }
        }
        private bool FilterDelivery(object o)
        {
            var item = o as Classes.DELIVERY;
            if (item == null)
            {
                return false;
            }
            return (item.ID.ToString().ToLower().Contains(DeliverySearchText.ToLower()) ||
                item.SupplierDelivery.SupplierName.ToString().ToLower().Contains(DeliverySearchText.ToLower()) ||
                item.OrderDate.ToString().ToLower().Contains(DeliverySearchText.ToLower()) ||
                item.DriverName.ToString().ToLower().Contains(DeliverySearchText.ToLower()) ||
                item.ArrivalDate.ToString().ToLower().Contains(DeliverySearchText.ToLower()));
        }
        #endregion
        #endregion

        #region ORDER
        ObservableCollection<Classes.ORDER> _orderList = new ObservableCollection<Classes.ORDER>();
        public ObservableCollection<Classes.ORDER> OrderList { get { return _orderList; } }
        #endregion
    }
}
