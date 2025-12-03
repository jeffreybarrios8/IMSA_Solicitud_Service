using Imsa.Solicitud.BusinessLogic.Interface;

namespace Imsa.Solicitud.BusinessLogic
{
    public class Cliente : ICliente
    {
        private readonly DataAccess.Interface.ICliente clienteDataAccess;

        public Cliente(DataAccess.Interface.ICliente clienteDataAccess)
        {
            this.clienteDataAccess = clienteDataAccess;
        }
        public IEnumerable<Model.Cliente> obtenerClientes()
        {
            return clienteDataAccess.ObtenerClientes();
        }
    }
}
