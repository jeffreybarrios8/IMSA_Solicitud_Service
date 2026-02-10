using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.DataAccess.Interface
{
    public interface ISolicitud
    {
        Task<Model.Solicitud?> GuardarSolicitud(Model.Solicitud solicitud);
        Task<string?> ObtenerFolio();
        Task<Model.DetalleSolicitud?> GuardarDetalleSolicitud(Model.DetalleSolicitud detalleSolicitud);
        Task<IEnumerable<Model.Solicitud>> ObtenerSolicitudes();
        Task<IEnumerable<Model.DetalleSolicitud>> ObtenerDetalleSolicitudPorId(int idSolicitud);
        Task<Model.Oferta> GuardarOferta(Model.Oferta oferta);
        Task<IEnumerable<Model.Analista>> ObtenerAnalistas();
        Task<IEnumerable<Model.Proveedor>> ObtenerProveedores();
        Task<Model.Analista?> GuardarAnalista(Model.Analista analista);
        Task<Model.Proveedor?> GuardarProveedor(Model.Proveedor proveedor);
        Task<bool> FinalizarSolicitud(Model.RequestFinalizarSolicitud requestFinalizar);

    }
}
