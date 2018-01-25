using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        #endregion

        #endregion
    }
}
