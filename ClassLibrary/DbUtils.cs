using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    public class DbUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "tasks_system";
            string username = "me";
            string password = "1234";

            return DbMySQLUtils.GetDBConnection(host, port, database, username, password);
        }
    }
}
