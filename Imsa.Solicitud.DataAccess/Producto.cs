using Imsa.Solicitud.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Imsa.Solicitud.Model;

namespace Imsa.Solicitud.DataAccess
{
    public class Producto : IProducto
    {
        private readonly IConnectionManager connectionManager;

        public Producto(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<IEnumerable<ProductoProveedorPrecio>> ObtenerProductoPrecioPorProveedor(int idProducto)
        {
           var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
              return await connection.QueryAsync<ProductoProveedorPrecio>(
                 "usp_Producto_Proveedores_Precio_Detalle",
                 new { IdProducto = idProducto },
                 commandType: System.Data.CommandType.StoredProcedure
                 );
        }

        public async Task<IEnumerable<Model.Producto>> ObtenerProductos()
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryAsync<Model.Producto>(
                "usp_Producto_Listar",
                commandType: System.Data.CommandType.StoredProcedure
                );
        }


    }
}
