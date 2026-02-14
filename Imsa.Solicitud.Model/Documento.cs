using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.Model
{
    public class Documento
    {
        public int IdTipoDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public string PlantillaHtml { get; set; }
        public string? Base64 { get; set; }
        public int? Activo { get; set; }
    }
}
