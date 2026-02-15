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

        public async Task<Model.Documento> Guardar(Model.Documento documento)
        {
           using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstAsync<Model.Documento>(
                sql: "usp_Documento_Guardar",
                param: new
                {
                    documento.IdSolicitud,
                    documento.NombreArchivo,
                    documento.MimeType,
                    documento.Base64
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Model.Documento>> ObtenerDocumentosPorIdSolicitud(int idSolicitud)
        {
           var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryAsync<Model.Documento>(
                sql: "usp_Documento_ObtenerPorSolicitud",
                param: new { IdSolicitud = idSolicitud },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public Documento(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }


    }
}
