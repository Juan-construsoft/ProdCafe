using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IRegistroCatacionRepository
    {
        Task<Result> GetAllRegistroCataciones();
        Task<Result> GetRegistroCatacionById(int? Id);
        Task<Result> InsertRegistroCatacion(CrearRegistroCatacionDto entity);
        Task<Result> UpdateRegistroCatacion(RegistroCatacionDto entity);
        Task<Result> DeleteRegistroCatacion(RegistroCatacionDto entity);
    }
}
