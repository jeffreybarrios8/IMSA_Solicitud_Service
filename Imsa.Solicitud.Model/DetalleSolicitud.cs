using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class DetalleSolicitud
    {
        public int IdDetalleSolicitud { get; set; }

        public string DescripcionProducto { get; set; } = string.Empty;

        public string UnidadMedida { get; set; } = string.Empty;

        public decimal CantidadRequerida { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal? SubTotal { get; set; }

        public int IdSolicitud
        {
            get; set;
        }
        public string Accion { get; set; }
    }
}
