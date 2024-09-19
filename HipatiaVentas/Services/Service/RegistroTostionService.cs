using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class RegistroTostionService : IRegistroTostionService
    {
        private readonly IRegistroTostionRepository RegistroTostionRepository;

        public RegistroTostionService(IRegistroTostionRepository _RegistroTostionRepository)
        {
            this.RegistroTostionRepository = _RegistroTostionRepository;
        }

        public Task<Result> DeleteRegistroTostion(RegistroTostionDto entity)
        {
            return RegistroTostionRepository.DeleteRegistroTostion(entity);
        }

        public Task<Result> GetRegistroTostionById(int Id)
        {
            return RegistroTostionRepository.GetRegistroTostionById(Id);
        }

        public Task<Result> GetAllRegistroTostiones()
        {
            return RegistroTostionRepository.GetAllRegistroTostiones();
        }

        public Task<Result> InsertRegistroTostion(CrearRegistroTostionDto entity)
        {
            return RegistroTostionRepository.InsertRegistroTostion(entity);
        }

        public Task<Result> UpdateRegistroTostion(RegistroTostionDto entity)
        {
            return RegistroTostionRepository.UpdateRegistroTostion(entity);
        }
    }
}
