using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.BusinessLogic.Interface
{
    public interface IDocumento
    {
        Task<IEnumerable<Model.Documento>> ObtenerTipoDocumento();
        Task<IEnumerable<Model.Documento>> GenerarDocumento(int IdSolicitud);
        Task<Model.Documento> Guardar(Model.Documento documento);
        Task<IEnumerable<Model.Documento>> ObtenerDocumentosPorIdSolicitud(int idSolicitud);

    }
}
