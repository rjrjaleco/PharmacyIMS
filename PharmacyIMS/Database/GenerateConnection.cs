using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyIMS.Database
{
    class GenerateConnection
    {
        //private static GenerateConnection _generateConnection;
        //public static GenerateConnection GenerateConnection
        //{
        //    get
        //    {
        //        if (_generateConnection == null)
        //        {
        //            _generateConnection = new GenerateConnection();
        //        }
        //        return _generateConnection;
        //    }
        //}
        //public GenerateConnection()
        //{
        //    var GenerateConnection
        //}
        public SqlConnection GenerateNewConnection()
        {
            var con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Rene John Jaleco\Desktop\PharmacyIMS\PharmacyIMS\Database\DatabaseTest.mdf");
            return con;
        }
    }
}
