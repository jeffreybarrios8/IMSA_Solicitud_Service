using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModficacion { get; set; }

        public string Codigo { get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }
        public string Origen { get; set; }
        public string Correo { get; set; }
        public int? Limite { get; set; }
        public int? Dias { get; set; }
        public string? NombreProveedor { get; set; }
        public int IdEstado { get; set; }
        public int IdMoneda { get; set; }
        public string? NombreMoneda { get; set; }
    }
}
