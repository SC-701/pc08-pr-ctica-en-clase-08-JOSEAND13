using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ProductoDa : IProductoDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public ProductoDa(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones
        public async Task <Guid> Agregar(ProductoRequest producto)
        {
            string query = @"AgregarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid(),
                idsubcategoria = producto.IdSubCategoria,
                nombre = producto.Nombre,
                descripcion = producto.Descripcion,
                precio = producto.Precio,
                stock = producto.Stock,
                codigoBarras = producto.CodigoBarras,
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, ProductoRequest producto)
        {
            await VerificarProductoExiste(Id);

            string query = @"EditarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = Id,
                idsubcategoria = producto.IdSubCategoria,
                nombre = producto.Nombre,
                descripcion = producto.Descripcion,
                precio = producto.Precio,
                stock = producto.Stock,
                codigoBarras = producto.CodigoBarras,
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarProductoExiste(Id);

            string query = @"EliminarProducto";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                id = Id
            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<ProductoResponse>> Obtener()
        {
            string query = @"ObtenerProductos";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoResponse>(query);

            return resultadoConsulta;
        }

        public async Task<ProductoDetalle> Obtener(Guid Id)
        {
            string query = @"ObtenerProducto";
            var resultadoConsulta = await _sqlConnection.QueryAsync<ProductoDetalle>(query,
                new { id = Id });

            return resultadoConsulta.FirstOrDefault();
        }
        #endregion

        #region Helpers
        private async Task VerificarProductoExiste(Guid id)
        {
            ProductoResponse? resultadoConsultaProducto = await Obtener(id);

            if (resultadoConsultaProducto == null)
            {
                throw new Exception("No se encontró el producto");
            }
        }
        #endregion
    }
}
