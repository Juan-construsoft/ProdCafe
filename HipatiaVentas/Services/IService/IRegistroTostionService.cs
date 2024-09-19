using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IRegistroTostionService
    {
        Task<Result> GetAllRegistroTostiones();
        Task<Result> GetRegistroTostionById(int Id);
        Task<Result> InsertRegistroTostion(CrearRegistroTostionDto entity);
        Task<Result> UpdateRegistroTostion(RegistroTostionDto entity);
        Task<Result> DeleteRegistroTostion(RegistroTostionDto entity);
    }
}
