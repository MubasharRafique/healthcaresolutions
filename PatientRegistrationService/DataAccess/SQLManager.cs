using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.DataAccess
{
    public class SQLManager
    {
        public string GetConnectionString(string dbName)
        {
            var conn = ConfigurationManager.ConnectionStrings["PatientDBContext"].ConnectionString.Replace("DBNamePlaceholder", dbName);
            return conn;
        }

        public DataTable Find(string connectionString, string query)
        {
            try
            {
                System.Data.DataTable dataTable = new System.Data.DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dataTable);
                    }

                    conn.Close();
                }

                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool InsertOrUpdateQuery(string connectionString, string query, Dictionary<string, string> parameters)
        {

            int totalRetries = 3;
            int currentTry = 1;

            while (true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;

                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue("@" + param.Key, param.Value);
                        }

                        connection.Open();

                        command.ExecuteNonQuery();

                        connection.Close();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    if (currentTry <= totalRetries)
                    {
                        currentTry += 1;
                        continue;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }
}
