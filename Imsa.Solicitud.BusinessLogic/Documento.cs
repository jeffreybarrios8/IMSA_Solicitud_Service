using Imsa.Solicitud.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.BusinessLogic
{
    public class Documento : IDocumento
    {
        private readonly DataAccess.Interface.IDocumento documentoDataAccess;
        private readonly ISolicitud solicitudDataAccess;
        public Documento(DataAccess.Interface.IDocumento documentoDataAccess, ISolicitud solicitud)
        {
            this.documentoDataAccess = documentoDataAccess;
            this.solicitudDataAccess = solicitud;
        }
        public  async Task<IEnumerable<Model.Documento>> ObtenerTipoDocumento()
        {
           return await documentoDataAccess.ObtenerTipoDocumento();
        }

        public async Task<IEnumerable<Model.Documento>> GenerarDocumento(int IdSolicitud)
        {
            var documentos = await ObtenerTipoDocumento();
            var resultado = new List<Model.Documento>();

            if (documentos != null && documentos.Any())
            {
                // Obtenemos la solicitud y sus detalles (Relación 1:N)
                var solicitud = await solicitudDataAccess.ObtenerSolicitudPorId(IdSolicitud);
                var ofertas = await solicitudDataAccess.ObtenerOfertaPorIdSolicitud(IdSolicitud);
                var culturaEspañol = new CultureInfo("es-NI");
                string fechaLarga = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy", culturaEspañol);

                if (solicitud != null)
                {
                    foreach (var documento in documentos)
                    {
                        // Inicializamos StringBuilder con la plantilla base de la BD
                        StringBuilder sb = new StringBuilder(documento.PlantillaHtml);

                        // 1. Reemplazo de datos de Cabecera
                        sb.Replace("[IdSolicitud]", solicitud.IdSolicitud.ToString());
                        sb.Replace("[NombreCliente]", solicitud.NombreSolicitante);
                        sb.Replace("[RucCliente]", solicitud.RucCliente);
                        sb.Replace("[FechaActualEnLetra]", fechaLarga);
                        sb.Replace("[NumeroFolio]", solicitud.NoFolio);

                        //2.Construcción de la Tabla Dinámica de Detalles
                        var cont = 0;
                        StringBuilder filasHtml = new StringBuilder();
                        foreach (var item in ofertas)
                        {
                            filasHtml.Append("<tr style='text-align: center;'>");

                            // Asignamos anchos fijos aproximados en línea para asegurar el ajuste
                            filasHtml.Append($"<td style='width: 5%;'>{++cont}</td>");
                            filasHtml.Append($"<td style='width: 10%;'>{item.CodigoSAC}</td>");

                            // Alineación a la izquierda para descripciones largas y evitar desborde
                            filasHtml.Append($"<td style='text-align: left; width: 30%; word-wrap: break-word;'>{item.DescripcionProducto}</td>");

                            filasHtml.Append($"<td style='width: 10%;'>{item.TipoImpuesto}</td>");
                            filasHtml.Append($"<td style='width: 8%;'>{item.UnidadMedida}</td>");
                            filasHtml.Append($"<td style='width: 7%;'>{item.CantidadRequerida}</td>");

                            // Calculamos el precio unitario si no viene directo (Subtotal / Cantidad)
                            decimal? precioUnit = item.SubTotal / item.CantidadRequerida;
                            filasHtml.Append($"<td style='width: 10%;'>{precioUnit:N2}</td>");

                            filasHtml.Append($"<td style='width: 10%;'>{item.SubTotal:N2}</td>");
                            filasHtml.Append($"<td style='width: 5%;'>{item.IVA:N2}</td>");
                            filasHtml.Append($"<td style='width: 10%;'>{item.Total:N2}</td>");

                            filasHtml.Append("</tr>");
                        }

                        // 3.Inyectamos la tabla completa en el marcador de la plantilla
                        sb.Replace("##TABLA_DETALLES##", filasHtml.ToString());

                        // Actualizamos el objeto con el HTML final procesado
                        documento.PlantillaHtml = sb.ToString();
                        resultado.Add(documento);
                    }
                }
            }
            return resultado;
        }
    }
}
