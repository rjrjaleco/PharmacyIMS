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
            _supplierview = CollectionViewSource.GetDefaultView(ProductList);
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
            if(SelectedProduct != null)
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
            if(item == null)
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
                item.Quantity.ToString().ToLower().Contains(ProductSearchText.ToLower()) );
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

        #region SUPPLIER
        private ICollectionView _supplierview;
        public Classes.SUPPLIER SelectedSupplier { get; set; }

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
                var window = new Windows.EditProductWindow();
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
        #endregion
    }
}
