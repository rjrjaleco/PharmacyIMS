using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PharmacyIMS.Classes
{
    class SUPPLIER
    {
        #region Private Fields
        private int _iD;
        private string _supplierName;
        private string _supplierAddress;
        private string _supplierDetails;
        #endregion
        #region Public Fields
        ObservableCollection<Classes.PRODUCT> _supplierProductList = new ObservableCollection<Classes.PRODUCT>();
        public ObservableCollection<Classes.PRODUCT> SupplierProductList { get { return _supplierProductList; } }
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
        public string SupplierName
        {
            get
            {
                return _supplierName;
            }
            set
            {
                _supplierName = value;
                OnPropertyChanged("SupplierName");
            }
        }
        public string SupplierAddress
        {
            get
            {
                return _supplierAddress;
            }
            set
            {
                _supplierAddress = value;
                OnPropertyChanged("SupplierAddress");
            }
        }
        public string SupplierDetails
        {
            get
            {
                return _supplierDetails;
            }
            set
            {
                _supplierDetails = value;
                OnPropertyChanged("SupplierDetails");
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
        public SUPPLIER() { }
        public SUPPLIER(int iD, string suppliername, string supplierAddress, string supplierDetails)
        {
            ID = iD;
            SupplierName = suppliername;
            SupplierAddress = supplierAddress;
            SupplierDetails = supplierDetails;
            _supplierProductList = new ObservableCollection<Classes.PRODUCT>();
        }
        #endregion
    }
}

