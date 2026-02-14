using Imsa.Solicitud.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMSA_Solicitud_Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [Authorize]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly Imsa.Solicitud.BusinessLogic.Interface.IDocumento _documentoBusinessLogic;
        public DocumentoController(Imsa.Solicitud.BusinessLogic.Interface.IDocumento documentoBusinessLogic)
        {
            _documentoBusinessLogic = documentoBusinessLogic;
        }
        [HttpPost]
        public async Task<IActionResult> GenerarDocumentos([FromBody] int idSolicitud)
        {
            try
            {
                var documentos = await _documentoBusinessLogic.GenerarDocumento(idSolicitud);
                var result = new ApiResponse<IEnumerable<Documento>>
                {
                    Status = 0,
                    Message = "Se obtuvo el tipo de documento correctamente",
                    Response = documentos
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al obtener el tipo de documento",
                    Response = ex.Message
                };
                return StatusCode(500, error);

            }
        }
    }
}
