using System;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBManager
    {
        private readonly string connectionString;

        public DBManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error executing query: " + ex.Message);
                    }
                }
            }
            return dataTable;
        }

        public bool ExecuteNonQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error executing non-query: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}