using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IRegistroTostionRepository
    {
        Task<Result> GetAllRegistroTostiones();
        Task<Result> GetRegistroTostionById(int Id);
        Task<Result> InsertRegistroTostion(CrearRegistroTostionDto entity);
        Task<Result> UpdateRegistroTostion(RegistroTostionDto entity);
        Task<Result> DeleteRegistroTostion(RegistroTostionDto entity);
    }
}
