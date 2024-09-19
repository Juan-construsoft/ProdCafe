using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IProductoRepository
    {
        Task<Result> GetAllProductos();
        Task<Result> GetProductoById(int? Id);
        Task<Result> InsertProducto(CrearProductoDto entity);
        Task<Result> UpdateProducto(ProductoDto entity);
        Task<Result> DeleteProducto(ProductoDto entity);

        Task<Result> GetProductoByPrecioId(int? Id);
    }
}
