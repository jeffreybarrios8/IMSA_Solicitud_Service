using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class ProductoProveedorPrecio
    {
        // === Información del PRODUCTO (Prefijo 'Producto') ===
        public int IdProducto { get; set; }
        public string ProductoCodigo { get; set; } = string.Empty; 
        public string ProductoDescripcion { get; set; } = string.Empty;
        public string? ProductoUnidadMedida { get; set; }
        public int ProductoCantidadExistencia { get; set; }
        public int ProductoCostoPromedio { get; set; }
        public int ProductoCostoTotalInventario { get; set; }
        public int ProductoIdTipoImpuesto { get; set; }
        public int ProductoIdEstado { get; set; }

        // === Información del PROVEEDOR (Prefijo 'Proveedor') ===
        public int IdProveedor { get; set; }
        public string NombreDelProveedor { get; set; } = string.Empty; 
        public string ProveedorCodigo { get; set; } = string.Empty; 
        public string ProveedorResponsable { get; set; } = string.Empty; 
        public string ProveedorTelefono { get; set; } = string.Empty;
        public int ProveedorIdMoneda { get; set; }

        // === Información del PRECIO Y UNIÓN ===
        public decimal PrecioVigente { get; set; } 
        public int IdPrecioProveedor { get; set; } 
        public int IdProductoProveedor { get; set; } 
    }
}
