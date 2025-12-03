using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.DataAccess.Interface
{
    public interface IProducto
    {
        Task<IEnumerable<Model.Producto>> ObtenerProductos();
        Task<IEnumerable<Model.ProductoProveedorPrecio>> ObtenerProductoPrecioPorProveedor(int idProducto);
    }
}
