using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyIMS.Classes
{
    class PRODUCT
    {
        #region Private Fields
        private int _iD;
        private string _productName;
        private string _genericName;
        private string _type;
        private string _form;
        private decimal _sellingPrice;
        private decimal _buyingPrice;
        private int _quantity;
        #endregion

        #region Public Fields
        public int ID
        {
            get
            {
                return _iD;
            }
            set
            {
                _iD = value;
                OnPropertyChanged("ID");
            }
        }
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
                OnPropertyChanged("ProductName");
            }
        }
        public string GenericName
        {
            get
            {
                return _genericName;
            }
            set
            {
                _genericName = value;
                OnPropertyChanged("GenericName");
            }
        }
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public string Form
        {
            get
            {
                return _form;
            }
            set
            {
                _form = value;
                OnPropertyChanged("Form");
            }
        }
        public decimal SellingPrice
        {
            get
            {
                return _sellingPrice;
            }
            set
            {
                _sellingPrice = value;
                OnPropertyChanged("SellingPrice");
            }
        }
        public decimal BuyingPrice
        {
            get
            {
                return _buyingPrice;
            }
            set
            {
                _buyingPrice = value;
                OnPropertyChanged("BuyingPrice");
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
        #endregion

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(e));
            }
        }
        #endregion

        #region Instantiate
        public PRODUCT() { }
        public PRODUCT(int iD, string productName, string genericName, string type, string form, decimal sellingPrice, decimal buyingPrice, int quantity)
        {
            ID = iD;
            ProductName = productName;
            GenericName = genericName;
            Type = type;
            Form = form;
            SellingPrice = sellingPrice;
            BuyingPrice = buyingPrice;
            Quantity = quantity;
        }
        #endregion
    }
}
