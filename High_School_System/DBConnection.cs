using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High_School_System
{
    class DBConnection
    {
        private static string DB_connection = "Data Source=Harrison-Progra\\HarrisonSQL;Initial Catalog=HSS;Integrated Security=True";
        
        public static String DB_Connection()
        {
            String con = DB_connection;
            return con;
        }
    }
}
