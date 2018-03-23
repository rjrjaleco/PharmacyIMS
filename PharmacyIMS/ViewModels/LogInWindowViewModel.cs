using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;

namespace PharmacyIMS.ViewModels
{
    class LogInWindowViewModel
    {
        public Classes.USER SelectedUser = new Classes.USER();
        ObservableCollection<Classes.USER> _userList = new ObservableCollection<Classes.USER>();
        public ObservableCollection<Classes.USER> UserList { get { return _userList; } }

        public int LogIn(string username, string password)
        {
            for(int x=0; x<UserList.Count; x++)
            {
                if(username == UserList[x].Username.ToString() && password == UserList[x].Password.ToString())
                {
                    SelectedUser = UserList[x];
                    return 1;
                } 
            }
            return 0;
        }
    }
}
