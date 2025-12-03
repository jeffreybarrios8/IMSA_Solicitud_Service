using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class EstadoSolicitud
    {
        public int IdEstadoSolicitud { get; set; } 
        public string Nombre { get; set; } = string.Empty; 
        public string Descripción { get; set; } = string.Empty; 

        public int IdEstado { get; set; } 

        public virtual Estado? Estado { get; set; } 
    }
}
