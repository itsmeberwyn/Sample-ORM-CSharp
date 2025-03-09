using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_ORM_Option.Dapper
{
    class DatabaseHelper
    {
        private const string ConnectionString = "Host=;Database=;Username=;Password=";

        public static IDbConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}
