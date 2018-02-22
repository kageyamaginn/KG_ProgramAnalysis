using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace KG_DBA
{
    
    public class DbConnection
    {
        /// <summary>
        /// DB file path, Initialize by main project start.
        /// </summary>
       public static String DbFilePath { get; set; }
       public static SQLiteConnection Conn
        {
            get
            {
                return new SQLiteConnection(String.Format("Data Source={0};Version=3;",DbFilePath));
            }
        }
    }
}
