using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.IService
{
    public interface ITipoCategoriaService
    {
        Task<Result> GetAllTipoCategorias();
        Task<Result> GetTipoCategoriaById(int? Id);
        Task<Result> InsertTipoCategoria(CrearTipoCategoriaDto entity);
        Task<Result> UpdateTipoCategoria(TipoCategoriaDto entity);
        Task<Result> DeleteTipoCategoria(TipoCategoriaDto entity);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}

