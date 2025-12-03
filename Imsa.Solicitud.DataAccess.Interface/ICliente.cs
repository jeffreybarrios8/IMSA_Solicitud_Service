using Imsa.Solicitud.Model;

namespace Imsa.Solicitud.DataAccess.Interface
{
    public interface ICliente
    {
        public IEnumerable<Model.Cliente> ObtenerClientes();
    }
}
