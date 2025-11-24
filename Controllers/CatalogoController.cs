using Imsa.Solicitud.BusinessLogic.Interface;
using Imsa.Solicitud.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSA_Solicitud_Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {

        private readonly ICliente _clienteBusinessLogic;

        public CatalogoController(ICliente clienteBusinessLogic)
        {
            _clienteBusinessLogic = clienteBusinessLogic;
        }

        [HttpGet]
        public IActionResult Clientes()
        {
            var clientes = _clienteBusinessLogic.obtenerClientes();
            var result = new ApiResponse<IEnumerable<Cliente>>
            {
                Status = 0,
                Message = "Clientes obtenidos correctamente",
                Response = clientes
            };
            return Ok(result);
        }
    }
}
