using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.IService
{
    public interface IProductoService
    {
        Task<Result> GetAllProductos();
        Task<Result> GetProductoById(int? Id);
        Task<Result> InsertProducto(CrearProductoDto entity);
        Task<Result> UpdateProducto(ProductoDto entity);
        Task<Result> DeleteProducto(ProductoDto entity);

        Task<List<SelectListItem>> GetSelectListItemsVenta();
        Task<List<SelectListItem>> GetSelectListItemsCompra();

        Task<Result> GetProductoByPrecioId(int? Id);        
    }
}
