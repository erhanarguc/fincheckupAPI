using Microsoft.Data.SqlClient;

namespace fincheckup.Models
{
    public class Database
    {
        public static string ConnectionString { get; set; }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

    }
}
