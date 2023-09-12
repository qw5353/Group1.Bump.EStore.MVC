using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bump.EStore.Infrastructure
{
    public static class SqlConnectionFactory
    {
        public static SqlConnection Create(string connectionString) => new SqlConnection(connectionString); 
        public static SqlConnection Create()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AppDbContext"].ToString();
            return new SqlConnection(connectionString);
        }
    }
}
