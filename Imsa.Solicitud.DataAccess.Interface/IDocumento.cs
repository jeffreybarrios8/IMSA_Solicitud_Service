using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.DataAccess.Interface
{
    public interface IDocumento
    {
        Task<IEnumerable<Model.Documento>> ObtenerTipoDocumento();
    }
}
