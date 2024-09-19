using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IMovimientoCajaRepository
    {
        Task<Result> GetAllMovimientoCajas();
        Task<Result> GetMovimientoCajaById(int Id);
        Task<Result> InsertMovimientoCaja(CrearMovimientoCajaDto entity);
        Task<Result> UpdateMovimientoCaja(MovimientoCajaDto entity);
        Task<Result> DeleteMovimientoCaja(MovimientoCajaDto entity);
    }
}
