using Microsoft.Data.SqlClient;

namespace LibraryManagement
{
    public class DatabaseHelper
    {
        private string connectionString =
            @"Server=.\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}