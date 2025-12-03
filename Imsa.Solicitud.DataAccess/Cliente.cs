using Dapper;
using Imsa.Solicitud.DataAccess.Interface;

namespace Imsa.Solicitud.DataAccess
{
    public class Cliente : ICliente
    {
        private readonly IConnectionManager connectionManager;

        public Cliente(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }
        public IEnumerable<Model.Cliente> ObtenerClientes()
        {
            using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return connection.Query<Model.Cliente>(
                sql: "usp_Cliente_Listar", 
                commandType: 
                System.Data.CommandType.StoredProcedure);

        }
    }
}
