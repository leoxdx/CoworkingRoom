using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace CoworkingRoom.Data
{
    internal class DbContext
    {
        public static NpgsqlConnection GetConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;
            return new NpgsqlConnection(connString);
        }
    }
}
