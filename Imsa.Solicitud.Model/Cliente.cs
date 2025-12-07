using System.ComponentModel.DataAnnotations;

namespace Imsa.Solicitud.Model
{
    public class Cliente: Auditoria
    {
       
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public string? Telefono { get; set; }
        public string Correo { get; set; }
        public int IdEstado { get; set; }
    }
}
