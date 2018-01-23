using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PharmacyIMS.ViewModels
{
    class MainWindowViewModel
    {
        #region PRODUCT
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
        #endregion
    }
}
