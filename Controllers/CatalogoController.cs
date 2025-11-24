using Imsa.Solicitud.BusinessLogic.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMSA_Solicitud_Service.Controllers
{
    [Route("api/[controller]")]
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
            return Ok(clientes);
        }
    }
}
