using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IDetalleVentaService
    {
        Task<Result> GetAllDetalleVentas();
        Task<Result> GetDetalleVentaById(int Id);
        Task<Result> InsertDetalleVenta(CrearDetalleVentaDto entity);
        Task<Result> UpdateDetalleVenta(DetalleVentaDto entity);
        Task<Result> DeleteDetalleVenta(DetalleVentaDto entity);
    }
}
