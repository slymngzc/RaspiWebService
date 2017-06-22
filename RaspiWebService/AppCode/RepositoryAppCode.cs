using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Text;

namespace RaspiWebService.AppCode
{
    public class RepositoryAppCode
    {
        string connectionString = ConfigurationManager.ConnectionStrings["RaspiValues"].ConnectionString;

        public bool AddValue(string key,string value)
        {
            try
            {
                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("INSERT INTO ValuesTable(Name,Value) VALUES('" + key + "','" + value + "');");

                    SqlCeCommand command = new SqlCeCommand();
                    command.Connection = conn;
                    command.CommandText = sql.ToString();

                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public KeyValueObject GetValue(string key)
        {
            KeyValueObject obj = null;

            try
            {
                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT * FROM ValuesTable WHERE Name='" + key + "'");

                    SqlCeCommand command = new SqlCeCommand();
                    command.Connection = conn;
                    command.CommandText = sql.ToString();

                    conn.Open();

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            obj = new KeyValueObject();
                            obj.Key = key;
                            obj.Value = reader["Value"].ToString();
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception)
            {
                obj = null;
            }

            return obj;
        }

        public List<KeyValueObject> GetAppSettings()
        {
            List<KeyValueObject> list = new List<KeyValueObject>();

            try
            {
                using (SqlCeConnection conn = new SqlCeConnection(connectionString))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("SELECT * FROM AppSettingsTable");

                    SqlCeCommand command = new SqlCeCommand();
                    command.Connection = conn;
                    command.CommandText = sql.ToString();

                    conn.Open();

                    using (SqlCeDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            KeyValueObject temp = new KeyValueObject();
                            temp.Key = reader["Name"].ToString();
                            temp.Value = reader["Value"].ToString();

                            list.Add(temp);
                        }
                    }

                    conn.Close();
                }
            }
            catch (Exception)
            {
            }

            return list;
        }
    }
}