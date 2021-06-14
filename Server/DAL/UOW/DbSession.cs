using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.UOW
{
    sealed class DbSession : IDbSession, IDisposable
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }

        public void Dispose()
        {
            Connection?.Dispose();
        }


        public DbSession(IConfiguration configuration, string connectionName)
        {
            Connection = new SqlConnection(configuration.GetConnectionString(connectionName));
            Connection.Open();
        }        
    }
}
