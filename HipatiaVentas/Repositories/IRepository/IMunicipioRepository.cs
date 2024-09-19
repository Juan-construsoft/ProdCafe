using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IMunicipioRepository
    {
        Task<Result> GetAllMunicipios();
        Task<Result> GetMunicipioById(int Id);
        Task<Result> InsertMunicipio(CrearMunicipioDto entity);
        Task<Result> UpdateMunicipio(MunicipioDto entity);
        Task<Result> DeleteMunicipio(MunicipioDto entity);
    }
}
