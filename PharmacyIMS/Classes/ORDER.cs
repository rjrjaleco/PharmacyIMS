using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace PharmacyIMS.Classes
{
    class ORDER
    {
        #region Private Fields
        private int _iD;
        private PRODUCT _orderProduct;
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
        public PRODUCT OrderProduct
        {
            get
            {
                return _orderProduct;
            }
            set
            {
                _orderProduct = value;
                OnPropertyChanged("OrderProduct");
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

        #region Instantiation
        public ORDER() { }
        public ORDER(int iD, PRODUCT orderProduct, int quantity)
        {
            ID = iD;
            OrderProduct = orderProduct;
            Quantity = quantity;
        }
        #endregion
    }
}
