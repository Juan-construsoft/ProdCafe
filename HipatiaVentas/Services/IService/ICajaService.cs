using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.IService
{
    public interface ICajaService
    {
        Task<Result> GetAllCajas();
        Task<Result> GetCajaById(int? Id);
        Task<Result> InsertCaja(CrearCajaDto entity);
        Task<Result> UpdateCaja(CajaDto entity);
        Task<Result> DeleteCaja(CajaDto entity);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}

