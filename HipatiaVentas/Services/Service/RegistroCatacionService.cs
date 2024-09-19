using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class RegistroCatacionService : IRegistroCatacionService
    {
        private readonly IRegistroCatacionRepository productoRepository;
        private readonly IMapper mapper;

        public RegistroCatacionService(IRegistroCatacionRepository _productoRepository, IMapper _mapper)
        {
            this.productoRepository = _productoRepository;
            this.mapper = _mapper;
        }

        public Task<Result> DeleteRegistroCatacion(RegistroCatacionDto entity)
        {
            return productoRepository.DeleteRegistroCatacion(entity);
        }

        public Task<Result> GetRegistroCatacionById(int? Id)
        {
            return productoRepository.GetRegistroCatacionById(Id);
        }

        public Task<Result> GetAllRegistroCataciones()
        {
            return productoRepository.GetAllRegistroCataciones();
        }

        public Task<Result> InsertRegistroCatacion(CrearRegistroCatacionDto entity)
        {
            return productoRepository.InsertRegistroCatacion(entity);
        }

        public Task<Result> UpdateRegistroCatacion(RegistroCatacionDto entity)
        {
            return productoRepository.UpdateRegistroCatacion(entity);
        }        
    }
}