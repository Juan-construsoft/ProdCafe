using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IDepartamentoService
    {
        Task<Result> GetAllDepartamentos();
        Task<Result> GetDepartamentoById(int Id);
        Task<Result> InsertDepartamento(CrearDepartamentoDto entity);
        Task<Result> UpdateDepartamento(DepartamentoDto entity);
        Task<Result> DeleteDepartamento(DepartamentoDto entity);
    }
}

