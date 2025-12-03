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

        [HttpGet]
        public async Task<IActionResult> ObtenerFolio()
        {

            try
            {
                var folio = await _solicitudBusinessLogic.ObtenerFolio();
                var result = new ApiResponse<string>
                {
                    Status = 0,
                    Message = "Se obtuvo el número de folio correctamente",
                    Response = folio
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al obtener el número de folio",
                    Response = ex.Message
                };

                return StatusCode(500, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarDetalle([FromBody] DetalleSolicitud detalleSolicitud)
        {
            try
            {
                var detalle = await _solicitudBusinessLogic.GuardarDetalleSolicitud(detalleSolicitud);
                var result = new ApiResponse<DetalleSolicitud>
                {
                    Status = 0,
                    Message = "Se guardó el detalle de la solicitud correctamente",
                    Response = detalle
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al guardar el detalle de la solicitud",
                    Response = ex.Message
                };
                return StatusCode(500, error);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Solicitudes()
        {
            try
            {
                var solicitudes = await _solicitudBusinessLogic.ObtenerSolicitudes();
                var result = new ApiResponse<IEnumerable<Solicitud>>
                {
                    Status = 0,
                    Message = "Se obtuvieron las solicitudes correctamente",
                    Response = solicitudes
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al obtener las solicitudes",
                    Response = ex.Message
                };
                return StatusCode(500, error);
            }

        }

        [HttpPost]
        public async Task<IActionResult> GuardarOferta([FromBody] Oferta oferta)
        {
            try
            {
                var ofertaGuardada = await _solicitudBusinessLogic.GuardarOferta(oferta);
                var result = new ApiResponse<Oferta>
                {
                    Status = 0,
                    Message = "Se guardó la oferta correctamente",
                    Response = ofertaGuardada
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al guardar la oferta",
                    Response = ex.Message
                };
                return StatusCode(500, error);
            }
        }

    }

}
