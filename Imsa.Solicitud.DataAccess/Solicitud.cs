using Dapper;
using Imsa.Solicitud.DataAccess.Interface;
using Imsa.Solicitud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imsa.Solicitud.DataAccess
{
    public class Solicitud : ISolicitud
    {
        private readonly IConnectionManager connectionManager;
         
        public Solicitud(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<bool> FinalizarSolicitud(RequestFinalizarSolicitud requestFinalizar)
        {
            using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.ExecuteAsync(
                "usp_FinalizarSolicitud",
                new
                {
                    requestFinalizar.IdSolicitudOriginal,
                    requestFinalizar.UsuarioAccion
                },
                commandType: System.Data.CommandType.StoredProcedure) > 0;
        }

        public async Task<Analista?> GuardarAnalista(Analista analista)
        {
            using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstOrDefaultAsync<Analista>(
                "usp_Analista_Guardar",
                new
                {
                    analista.IdAnalista,
                    analista.PrimerNombre,
                    analista.SegundoNombre,
                    analista.PrimerApellido,
                    analista.SegundoApellido,
                    analista.Correo,
                    analista.Telefono,
                    analista.UsuarioCreacion,
                    analista.IdEstado
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<DetalleSolicitud?> GuardarDetalleSolicitud(DetalleSolicitud detalleSolicitud)
        {
            using var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstOrDefaultAsync<DetalleSolicitud>(
                "usp_DetalleSolicitud_Guardar",
                new
                {
                    detalleSolicitud.IdDetalleSolicitud,
                    detalleSolicitud.DescripcionProducto,
                    detalleSolicitud.UnidadMedida,
                    detalleSolicitud.CantidadRequerida,
                    detalleSolicitud.PrecioUnitario,
                    detalleSolicitud.IdSolicitud,
                    detalleSolicitud.Accion
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Oferta?> GuardarOferta(Oferta oferta)
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstOrDefaultAsync<Oferta>(
                "usp_Oferta_Guardar",
                new
                {
                    oferta.CodigoSAC,
                    oferta.CantidadRequerida,
                    oferta.SubTotal,
                    oferta.IVA,
                    oferta.Total,
                    oferta.IdSolicitud,
                    oferta.IdProducto,
                    oferta.TipoImpuesto,
                    oferta.UsuarioCreacion
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Proveedor?> GuardarProveedor(Proveedor proveedor)
        {
           var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstOrDefaultAsync<Proveedor>(
                "usp_Proveedor_Guardar",
                new
                {
                    proveedor.IdProveedor,
                    proveedor.Codigo,
                    proveedor.Responsable,
                    proveedor.Telefono,
                    proveedor.Origen,
                    proveedor.Correo,
                    proveedor.Limite,
                    proveedor.UsuarioCreacion,  
                    proveedor.Dias,
                    proveedor.IdEstado,
                    proveedor.IdMoneda,
                    proveedor.NombreProveedor
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<Model.Solicitud?> GuardarSolicitud(Model.Solicitud solicitud)
        {
            using var connection =  connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryFirstOrDefaultAsync<Model.Solicitud>(
                "usp_Solicitud_Guardar",
                new
                {
                    solicitud.IdSolicitud,
                    solicitud.NoScSolicitante,
                    solicitud.NombreSolicitante,
                    solicitud.NoFolio,
                    solicitud.FechaReciboUcc,
                    solicitud.EncargadoAdquisicion,
                    solicitud.EmailEncargadoAdquisicion,
                    solicitud.TelefonoEncargadoAdquisicion,
                    solicitud.IdEstadoSolicitud,
                    solicitud.IdCliente,
                    solicitud.IdEstado,
                    solicitud.IdAnalista, 
                    solicitud.UsuarioCreacion
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Analista>> ObtenerAnalistas()
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryAsync<Analista>(
                "usp_Analista_Listar",
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DetalleSolicitud>> ObtenerDetalleSolicitudPorId(int idSolicitud)
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryAsync<DetalleSolicitud>(
                "usp_DetalleSolicitudById",
                new { IdSolicitud = idSolicitud },
                commandType: System.Data.CommandType.StoredProcedure);

        }

        public async Task<string?> ObtenerFolio()
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.ExecuteScalarAsync<string>(
                "GenerarFolio",
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Proveedor>> ObtenerProveedores()
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryAsync<Proveedor>(
                "usp_Proveedor_Listar",
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Model.Solicitud>> ObtenerSolicitudes()
        {
            var connection = connectionManager.GetConnection(ConnectionManager.CONNECTION_STRING_NAME);
            return await connection.QueryAsync<Model.Solicitud>(
                "usp_Solicitud_Listar",
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
