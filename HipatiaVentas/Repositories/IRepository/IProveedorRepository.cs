using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IProveedorRepository
    {
        Task<Result> GetAllProveedores();
        Task<Result> GetProveedorById(int? Id);
        Task<Result> InsertProveedor(CrearProveedorDto entity);
        Task<Result> UpdateProveedor(ProveedorDto entity);
        Task<Result> DeleteProveedor(ProveedorDto entity);
    }
}
