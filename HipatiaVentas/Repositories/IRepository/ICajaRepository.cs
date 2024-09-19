using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface ICajaRepository
    {
        Task<Result> GetAllCajas();
        Task<Result> GetCajaById(int? Id);
        Task<Result> InsertCaja(CrearCajaDto entity);
        Task<Result> UpdateCaja(CajaDto entity);
        Task<Result> DeleteCaja(CajaDto entity);
    }
}