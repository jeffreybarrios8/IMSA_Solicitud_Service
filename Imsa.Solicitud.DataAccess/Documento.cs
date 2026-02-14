using Dapper;
using Imsa.Solicitud.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.DataAccess
{
    public class Documento : IDocumento
    {
        private readonly IConnectionManager connectionManager;
        public  async Task<IEnumerable<Model.Documento>> ObtenerTipoDocumento()
        {
            using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return connection.Query<Model.Documento>(
               sql: "usp_TipoDocumento_Obtener",
               commandType:
               System.Data.CommandType.StoredProcedure);
        }

        public Documento(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }


    }
}
