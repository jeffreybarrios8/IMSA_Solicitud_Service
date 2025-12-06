using Imsa.Solicitud.BusinessLogic.Interface;
using Imsa.Solicitud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.BusinessLogic
{
    public class Solicitud : ISolicitud
    {

        private readonly DataAccess.Interface.ISolicitud solicitudDataAccess;

        public Solicitud(DataAccess.Interface.ISolicitud solicitudDataAccess)
        {
            this.solicitudDataAccess = solicitudDataAccess;
        }

        public async Task<Analista?> GuardarAnalista(Analista analista)
        {
            return await solicitudDataAccess.GuardarAnalista(analista);
        }

        public async Task<DetalleSolicitud?> GuardarDetalleSolicitud(DetalleSolicitud detalleSolicitud)
        {
            return await solicitudDataAccess.GuardarDetalleSolicitud(detalleSolicitud);
        }

        public async Task<Oferta> GuardarOferta(Oferta oferta)
        {
           return await solicitudDataAccess.GuardarOferta(oferta);
        }

        public Task<Model.Solicitud?> GuardarSolicitud(Model.Solicitud solicitud)
        {
            ArgumentNullException.ThrowIfNull(solicitud);
            if (solicitud.IdAnalista == 0) solicitud.IdAnalista = null;
            return solicitudDataAccess.GuardarSolicitud(solicitud);
        }

        public async Task<IEnumerable<Analista>> ObtenerAnalistas()
        {
            return await solicitudDataAccess.ObtenerAnalistas();
        }

        public async Task<string?> ObtenerFolio()
        {
            return await solicitudDataAccess.ObtenerFolio();
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedores()
        {
            return await solicitudDataAccess.ObtenerProveedores();
        }

        public async Task<IEnumerable<Model.Solicitud>> ObtenerSolicitudes()
        {
            var solicitudes = await solicitudDataAccess.ObtenerSolicitudes();
            if (solicitudes != null && solicitudes.Any())
            {
                foreach (var item in solicitudes)
                {
                    var detalleSolicitudes = await solicitudDataAccess.ObtenerDetalleSolicitudPorId(item.IdSolicitud);
                    if (detalleSolicitudes != null && detalleSolicitudes.Any())
                    {
                        item.DetalleSolicitud = detalleSolicitudes;

                    }
                }
            }
            return solicitudes ?? [];
        }
    }
}
