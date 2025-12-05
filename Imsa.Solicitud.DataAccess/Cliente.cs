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

        public async Task<Model.Cliente> GuardarCliente(Model.Cliente cliente)
        {
           using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstAsync<Model.Cliente>(
                sql: "usp_Cliente_Guardar",
                param: new
                {
                    cliente.IdCliente,
                    cliente.Nombre,
                    cliente.Ruc,
                    cliente.Telefono,
                    cliente.Correo,
                    cliente.IdEstado,
                    cliente.UsuarioCreacion,
                    
                },
                commandType: System.Data.CommandType.StoredProcedure);
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
