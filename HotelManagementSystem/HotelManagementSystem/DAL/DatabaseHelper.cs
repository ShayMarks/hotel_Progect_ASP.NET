using System.Configuration;
using System.Data.SqlClient;

namespace HotelManagementSystem.DAL
{
    public static class DatabaseHelper
    {
        // This method returns a new SqlConnection object using the connection string from web.config
        public static SqlConnection GetConnection()
        {
            // Get the connection string from the web.config file
            string connectionString = ConfigurationManager.ConnectionStrings["HotelManagementDB"].ConnectionString;
            // Return a new SqlConnection object
            return new SqlConnection(connectionString);
        }
    }
}
