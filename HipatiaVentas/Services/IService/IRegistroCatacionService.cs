using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IRegistroCatacionService
    {
        Task<Result> GetAllRegistroCataciones();
        Task<Result> GetRegistroCatacionById(int? Id);
        Task<Result> InsertRegistroCatacion(CrearRegistroCatacionDto entity);
        Task<Result> UpdateRegistroCatacion(RegistroCatacionDto entity);
        Task<Result> DeleteRegistroCatacion(RegistroCatacionDto entity);
    }
}
