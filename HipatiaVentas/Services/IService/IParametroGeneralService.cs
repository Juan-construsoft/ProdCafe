using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.IService
{
    public interface IParametroGeneralService
    {
        Task<Result> GetAllParametroGenerales();
        Task<Result> GetParametroGeneralById(int? Id);
        Task<Result> GetParametroGeneralByCategoria(int Id);
        Task<Result> InsertParametroGeneral(CrearParametroGeneralDto entity);
        Task<Result> UpdateParametroGeneral(ParametroGeneralDto entity);
        Task<Result> DeleteParametroGeneral(ParametroGeneralDto entity);

        Task<List<SelectListItem>> GetSelectListItems(int vCategoria);
    }
}
