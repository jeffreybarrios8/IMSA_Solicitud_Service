using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Oferta
    {
        public int IdOferta { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; } 
        public string? UsuarioModificacion { get; set; } 

        // Datos Específicos de la Oferta
        public string CodigoSAC { get; set; }
        public int CantidadRequerida { get; set; }
        public decimal? SubTotal { get; set; } 
        public decimal? IVA { get; set; } 
        public decimal Total { get; set; }
        public string TipoImpuesto { get; set; }

        // Claves Foráneas
        public int IdSolicitud { get; set; }
        public int IdProducto { get; set; }

        public Solicitud? Solicitud { get; set; }

        public Producto? Producto { get; set; }
    }
}
