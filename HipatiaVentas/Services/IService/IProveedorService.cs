using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.IService
{
    public interface IProveedorService
    {
        Task<Result> GetAllProveedores();
        Task<Result> GetProveedorById(int? Id);
        Task<Result> InsertProveedor(CrearProveedorDto entity);
        Task<Result> UpdateProveedor(ProveedorDto entity);
        Task<Result> DeleteProveedor(ProveedorDto entity);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}
