using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IVentaRepository
    {
        Task<Result> GetAllVentas();
        Task<Result> GetVentaById(int Id);
        Task<Result> InsertVenta(CrearVentaDto entity);
        Task<Result> UpdateVenta(VentaDto entity);
        Task<Result> DeleteVenta(VentaDto entity);

        Task<Result> GetVentaDetalleById(int? Id);
    }
}
