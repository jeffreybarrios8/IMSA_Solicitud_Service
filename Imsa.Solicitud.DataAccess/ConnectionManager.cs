using Imsa.Solicitud.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Imsa.Solicitud.DataAccess
{
    public class ConnectionManager : IConnectionManager
    {
        public const string CONNECTION_STRING_NAME = "Solicitud";
        private readonly IConfiguration configuration;

        public ConnectionManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IDbConnection GetConnection(string connectionString)
        {
            var connection = configuration.GetConnectionString("Solicitud");
            return new SqlConnection(connection);
        }
    }
}
