using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PharmacyIMS.Classes
{
    class DELIVERY
    {
        #region Private Fields
        private int _iD;
        private DateTime _orderDate;
        private DateTime _arrivalDate;
        private SUPPLIER _supplierDelivery;
        private string _driverName;
        #endregion
        ObservableCollection<Classes.ORDER> _deliveryOrderList = new ObservableCollection<Classes.ORDER>();
        public ObservableCollection<Classes.ORDER> DeliveryOrderList { get { return _deliveryOrderList; } }
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
        public DateTime OrderDate
        {
            get
            {
                return _orderDate;
            }
            set
            {
                _orderDate = value;
                OnPropertyChanged("OrderDate");
            }
        }
        public DateTime ArrivalDate
        {
            get
            {
                return _arrivalDate;
            }
            set
            {
                _arrivalDate = value;
                OnPropertyChanged("ArrivalDate");
            }
        }
        public SUPPLIER SupplierDelivery
        {
            get
            {
                return _supplierDelivery;
            }
            set
            {
                _supplierDelivery = value;
                OnPropertyChanged("SupplierDelivery");
            }
        }
        public string DriverName
        {
            get
            {
                return _driverName;
            }
            set
            {
                _driverName = value;
                OnPropertyChanged("DriverName");
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
        public DELIVERY() { }
        public DELIVERY(int iD, DateTime arrivalDate, SUPPLIER supplierDelivery, string driverName)
        {
            ID = iD;
            OrderDate = DateTime.Now;
            ArrivalDate = arrivalDate;
            supplierDelivery = SupplierDelivery;
            DriverName = driverName;
            _deliveryOrderList = new ObservableCollection<Classes.ORDER>();
        }
        #endregion
    }
}
