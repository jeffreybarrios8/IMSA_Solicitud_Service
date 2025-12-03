using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Producto
    {
        public int IdProducto { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; } = string.Empty;
        public DateTime? FechaModificacion { get; set; } // Nullable, puede no tener valor
        public string? UsuarioModficacion { get; set; } // Nullable, puede no tener valor

        public string CodigoMaterial { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string? UnidadMedida { get; set; } 

        public int CantidadExistencia { get; set; }
        public decimal CostoPromedio { get; set; }
        public decimal CostoTotalInventario { get; set; }
        public int IdTipoImpuesto { get; set; }
        public int IdEstado { get; set; }
        public string NombreImpuesto { get; set; }
    }
}
