using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BmsServer.Context
{
    public class DBContext
    {
        public IConfiguration _configuration { get; set; }
        public string _connectionString { get; set; }
        public DBContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Database");
         
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
