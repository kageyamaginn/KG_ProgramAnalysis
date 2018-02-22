using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KG_ProgramAnalysis
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mainform());
            KG_DBA.DbConnection.DbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db_1.db");
        }
    }
}
