using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Solicitud: Auditoria
    {
        public int IdSolicitud { get; set; } 

        public int NoScSolicitante { get; set; } 
        public string NombreSolicitante { get; set; } = string.Empty; 
        public string NoFolio { get; set; } = string.Empty; 

        public DateTime FechaReciboUcc { get; set; } 
        public string EncargadoAdquisicion { get; set; } = string.Empty; 
        public string? EmailEncargadoAdquisicion { get; set; } 
        public string TelefonoEncargadoAdquisicion { get; set; } = string.Empty; 

        public int IdEstadoSolicitud { get; set; } 
        public int IdCliente { get; set; } 
        public int IdEstado { get; set; } 
        public int? IdAnalista { get; set; }
        public string NombreEstadoSolicitud { get; set; } = string.Empty;
        public IEnumerable<DetalleSolicitud> DetalleSolicitud { get; set; }
        public string RucCliente { get; set; }
        public string NombreCliente { get; set; }
        public string? NombreAnalista { get; set; }


    }
}
