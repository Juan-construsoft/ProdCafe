using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IDetalleCompraService
    {
        Task<Result> GetAllDetalleCompras();
        Task<Result> GetDetalleCompraById(int Id);
        Task<Result> InsertDetalleCompra(CrearDetalleCompraDto entity);
        Task<Result> UpdateDetalleCompra(DetalleCompraDto entity);
        Task<Result> DeleteDetalleCompra(DetalleCompraDto entity);
    }
}

