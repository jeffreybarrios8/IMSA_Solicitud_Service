using Imsa.Solicitud.BusinessLogic.Interface;
using Imsa.Solicitud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.BusinessLogic
{
    public class Producto : IProducto
    {
        private readonly DataAccess.Interface.IProducto productoDataAccess;
        public Producto(DataAccess.Interface.IProducto productoDataAccess)
        {
            this.productoDataAccess = productoDataAccess;
        }

        public async Task<IEnumerable<ProductoProveedorPrecio>> ObtenerProductoPrecioPorProveedor(int idProducto)
        {
            return await productoDataAccess.ObtenerProductoPrecioPorProveedor(idProducto);
        }

        public async Task<IEnumerable<Model.Producto>> ObtenerProductos()
        {
            return await productoDataAccess.ObtenerProductos();
        }
    }
}
