using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyIMS.Database
{
    class DatabaseLocator
    {
        private static GenerateConnection _generateConnection;
        public static GenerateConnection GenerateConnection
        {
            get
            {
                if (_generateConnection == null)
                {
                    _generateConnection = new GenerateConnection();
                }
                return _generateConnection;
            }
        }
    }
}
