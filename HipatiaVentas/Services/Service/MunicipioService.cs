using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository municipioRepository;

        public MunicipioService(IMunicipioRepository _municipioRepository)
        {
            this.municipioRepository = _municipioRepository;
        }

        public Task<Result> DeleteMunicipio(MunicipioDto entity)
        {
            return municipioRepository.DeleteMunicipio(entity);
        }

        public Task<Result> GetMunicipioById(int Id)
        {
            return municipioRepository.GetMunicipioById(Id);
        }

        public Task<Result> GetAllMunicipios()
        {
            return municipioRepository.GetAllMunicipios();
        }

        public Task<Result> InsertMunicipio(CrearMunicipioDto entity)
        {
            return municipioRepository.InsertMunicipio(entity);
        }

        public Task<Result> UpdateMunicipio(MunicipioDto entity)
        {
            return municipioRepository.UpdateMunicipio(entity);
        }
    }
}

