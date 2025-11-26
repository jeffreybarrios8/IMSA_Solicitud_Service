using Imsa.Solicitud.BusinessLogic.Interface;
using Imsa.Solicitud.Model;
using Microsoft.AspNetCore.Mvc;

namespace IMSA_Solicitud_Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ISolicitud _solicitudBusinessLogic;
        public SolicitudController(ISolicitud solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        [HttpPost]
        public async Task<IActionResult> Guardar([FromBody] Solicitud sol)
        {

            try
            {
                var solicitud = await _solicitudBusinessLogic.GuardarSolicitud(sol);
                var result = new ApiResponse<Solicitud>
                {
                    Status = 0,
                    Message = "Se guardó correctamente",
                    Response = solicitud
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al obtener los clientes",
                    Response = ex.Message
                };

                return StatusCode(500, error);
            }
        }
    }
}
