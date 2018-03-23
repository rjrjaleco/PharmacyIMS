using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PharmacyIMS.Classes
{
    class USER
    {
        #region Private Fields
        private int _iD;
        private string _username;
        private string _password;
        private string _level;
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
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
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
        public USER() { }
        public USER(int iD, string username, string password, string level)
        {
            ID = iD;
            Username = username;
            Password = password;
            Level = level;
        }
        #endregion
    }
}
