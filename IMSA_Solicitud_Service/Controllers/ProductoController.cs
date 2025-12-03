using Imsa.Solicitud.BusinessLogic.Interface;
using Imsa.Solicitud.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMSA_Solicitud_Service.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
       
        private readonly IProducto _productoBusinessLogic;
        public ProductoController(IProducto productoBusinessLogic)
        {
            _productoBusinessLogic = productoBusinessLogic;
        }
        [HttpPost]
        public async Task<IActionResult> Cotizar([FromBody] int idProducto)
        {
            try
            {
                var productos = await _productoBusinessLogic.ObtenerProductoPrecioPorProveedor(idProducto);
                var result = new ApiResponse<IEnumerable<ProductoProveedorPrecio>>
                {
                    Status = 0,
                    Message = "El producto no es cotizable",
                    Response = productos
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new ApiResponse<string>
                {
                    Status = 1,
                    Message = "Error al obtener la cotización del producto",
                    Response = ex.Message
                };
                return StatusCode(500, error);
            }
        }

    }
}
