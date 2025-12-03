using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Analista: Auditoria
    {
        public int IdAnalista { get; set; } // int not null, identity

        public string PrimerNombre { get; set; } = string.Empty; 
        public string? SegundoNombre { get; set; } 
        public string PrimerApellido { get; set; } = string.Empty; 
        public string? SegundoApellido { get; set; } 
        public string? Telefono { get; set; } 
        public string? Correo { get; set; } 

        public int IdEstado { get; set; } 

        public virtual Estado? Estado { get; set; } 
    }
}
