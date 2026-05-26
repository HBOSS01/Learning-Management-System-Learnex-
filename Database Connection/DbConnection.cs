using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS
{
    public static class DbConnection
    {
        private static string connectionString = "server=LMS\\SQLEXPRESS;database=LMS;integrated Security=SSPI;";
        public static SqlConnection GetConnection()
        {
            try
            {
                return new SqlConnection(connectionString);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Connection Error: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection Error: " + ex.Message);
                throw;
            }
        }
    }
}

