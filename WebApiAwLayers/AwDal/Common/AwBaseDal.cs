using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwDal.Common
{
    public class AwBaseDal
    {
        public string ConnectionString { get; set; }
        public AwBaseDal(string connectionString)
        {
            this.ConnectionString = connectionString;
        } 
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
