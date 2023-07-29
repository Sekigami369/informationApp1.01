using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace informationApp1._01
{
    public class DBconn
    {
        string connectionString = "Server=localhost;Database=MyDatabase;Trusted_Connection=true;";
        public DBconn()
        {
            SqlConnection connection = new SqlConnection(connectionString);
        }

    }
}
