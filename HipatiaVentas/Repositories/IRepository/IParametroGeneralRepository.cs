using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IParametroGeneralRepository
    {
        Task<Result> GetAllParametroGenerales();
        Task<Result> GetParametroGeneralById(int? Id);
        Task<Result> GetParametroGeneralByCategoria(int Id);
        Task<Result> InsertParametroGeneral(CrearParametroGeneralDto entity);
        Task<Result> UpdateParametroGeneral(ParametroGeneralDto entity);
        Task<Result> DeleteParametroGeneral(ParametroGeneralDto entity);
    }
}
