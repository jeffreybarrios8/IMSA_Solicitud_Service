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
        private readonly IProducto _productoBusinessLogic;

        public CatalogoController(ICliente clienteBusinessLogic, IProducto productoBusinessLogic)
        {
            _clienteBusinessLogic = clienteBusinessLogic;
            _productoBusinessLogic = productoBusinessLogic;
        }

        [HttpGet]
        public IActionResult Clientes()
        {
            try
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
        public async Task<IActionResult> Productos()
        {
            try
            {
                var productos = await _productoBusinessLogic.ObtenerProductos();
                var result = new ApiResponse<IEnumerable<Producto>>
                {
                    Status = 0,
                    Message = "Productos obtenidos correctamente",
                    Response = productos
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al obtener los productos",
                    Response = ex.Message
                };
                return StatusCode(500, error);
            }
        }

    }
}
