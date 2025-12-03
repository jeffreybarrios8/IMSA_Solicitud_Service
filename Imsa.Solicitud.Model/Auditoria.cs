using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Auditoria
    {
        public DateTime FechaCreacion { get; set; } 
        public string UsuarioCreacion { get; set; } = string.Empty; 
        public DateTime? FechaModificacion { get; set; } 
        public string? UsuarioModficacion { get; set; } 
    }
}
