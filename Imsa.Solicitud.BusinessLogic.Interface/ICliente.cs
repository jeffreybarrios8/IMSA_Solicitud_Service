using Imsa.Solicitud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.BusinessLogic.Interface
{
    public interface ICliente
    {

        public IEnumerable<Model.Cliente> obtenerClientes();
        Task<Model.Cliente> GuardarCliente(Model.Cliente cliente);


    }
}
