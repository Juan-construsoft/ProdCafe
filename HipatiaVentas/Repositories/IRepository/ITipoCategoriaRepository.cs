using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface ITipoCategoriaRepository
    {
        Task<Result> GetAllTipoCategorias();
        Task<Result> GetTipoCategoriaById(int? Id);
        Task<Result> InsertTipoCategoria(CrearTipoCategoriaDto entity);
        Task<Result> UpdateTipoCategoria(TipoCategoriaDto entity);
        Task<Result> DeleteTipoCategoria(TipoCategoriaDto entity);
    }
}
