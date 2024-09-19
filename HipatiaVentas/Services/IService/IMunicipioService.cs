using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface IMunicipioService
    {
        Task<Result> GetAllMunicipios();
        Task<Result> GetMunicipioById(int Id);
        Task<Result> InsertMunicipio(CrearMunicipioDto entity);
        Task<Result> UpdateMunicipio(MunicipioDto entity);
        Task<Result> DeleteMunicipio(MunicipioDto entity);
    }
}

