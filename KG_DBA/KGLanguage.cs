using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace KG_DBA
{
    public class KGLanguage
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompileLanguage { get; set; }
        public bool IsExplainLanguage { get; set; }
        public bool IsProcessLanguage { get; set; }
        public bool IsObjectiveLanguage { get; set; }
        public bool IsScriptLanguage { get; set; }

        public void Add(KGLanguage item)
        {
            SQLiteConnection conn = DbConnection.Conn;
            SQLiteCommand cmd = new SQLiteCommand("insert into kg_language values(:Name, :Description, :IsCompileLanguage, :IsExplainLanguage, :IsProcessLanguage, :IsObjectiveLanguage, :IsScriptLanguage)", conn);
            cmd.Parameters.Add(new SQLiteParameter("Name", item.Name));
            cmd.Parameters.Add(new SQLiteParameter("Description", item.Description));
            cmd.Parameters.Add(new SQLiteParameter("IsCompileLanguage", item.IsCompileLanguage));
            cmd.Parameters.Add(new SQLiteParameter("IsExplainLanguage", item.IsExplainLanguage));
            cmd.Parameters.Add(new SQLiteParameter("IsProcessLanguage", item.IsProcessLanguage));
            cmd.Parameters.Add(new SQLiteParameter("IsObjectiveLanguage", item.IsObjectiveLanguage));
            cmd.Parameters.Add(new SQLiteParameter("IsScriptLanguage", item.IsScriptLanguage));
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public List<KGLanguage> Get(string wherecase="", string ordercase="")
        {
            List<KGLanguage> results = new List<KGLanguage>();
            SQLiteConnection conn = DbConnection.Conn;
            SQLiteCommand cmd = new SQLiteCommand("select * from kg_language", conn);
            try
            {
                conn.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KGLanguage item = new KGLanguage();
                    item.Name = reader.IsDBNull(0) ? "" : reader.GetString(0);
                    item.Description = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    item.IsCompileLanguage = reader.IsDBNull(2) ? false : reader.GetBoolean(2);
                    item.IsExplainLanguage = reader.IsDBNull(3) ? false : reader.GetBoolean(3);
                    item.IsProcessLanguage = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                    item.IsObjectiveLanguage = reader.IsDBNull(5) ? false : reader.GetBoolean(5);
                    item.IsScriptLanguage = reader.IsDBNull(6) ? false : reader.GetBoolean(6);
                    
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return results;
        }
    }
}
