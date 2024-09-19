using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IMovimientoCajaService
    {
        Task<Result> GetAllMovimientoCajas();
        Task<Result> GetMovimientoCajaById(int Id);
        Task<Result> InsertMovimientoCaja(CrearMovimientoCajaDto entity);
        Task<Result> UpdateMovimientoCaja(MovimientoCajaDto entity);
        Task<Result> DeleteMovimientoCaja(MovimientoCajaDto entity);
    }
}

