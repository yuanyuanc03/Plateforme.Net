using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacchus.MVC.Util
{
    /// <summary>
    /// Get connection with database SQLite.
    /// </summary>
    class GetConnection
    {
        public static SQLiteConnection Connection;

        /// <summary>
        /// Connect the database in the current environment directory.
        /// </summary>
        /// <returns><c>SQLiteConnection</c></c></returns>
        public static SQLiteConnection ConnectionSQLite()
        {
            string Path = "Data Source = " + System.Environment.CurrentDirectory + "/Bacchus.SQLite";

            if (Connection == null)
            {
                Connection = new SQLiteConnection(Path);
                if (Connection.State == ConnectionState.Closed)
                    Connection.Open();
                return Connection;
            }
            else
            {
                return Connection;
            }
        }
    }
}
