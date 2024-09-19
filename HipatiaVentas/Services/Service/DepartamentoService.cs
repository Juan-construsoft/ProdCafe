using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository departamentoRepository;

        public DepartamentoService(IDepartamentoRepository _departamentoRepository)
        {
            this.departamentoRepository = _departamentoRepository;
        }

        public Task<Result> DeleteDepartamento(DepartamentoDto entity)
        {
            return departamentoRepository.DeleteDepartamento(entity);
        }

        public Task<Result> GetDepartamentoById(int Id)
        {
            return departamentoRepository.GetDepartamentoById(Id);
        }

        public Task<Result> GetAllDepartamentos()
        {
            return departamentoRepository.GetAllDepartamentos();
        }

        public Task<Result> InsertDepartamento(CrearDepartamentoDto entity)
        {
            return departamentoRepository.InsertDepartamento(entity);
        }

        public Task<Result> UpdateDepartamento(DepartamentoDto entity)
        {
            return departamentoRepository.UpdateDepartamento(entity);
        }
    }
}

