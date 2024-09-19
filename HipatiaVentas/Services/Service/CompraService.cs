using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository compraRepository;

        public CompraService(ICompraRepository _compraRepository)
        {
            this.compraRepository = _compraRepository;
        }

        public Task<Result> DeleteCompra(CompraDto entity)
        {
            return compraRepository.DeleteCompra(entity);
        }

        public Task<Result> GetCompraById(int? Id)
        {
            return compraRepository.GetCompraById(Id);
        }

        public Task<Result> GetAllCompras()
        {
            return compraRepository.GetAllCompras();
        }

        public Task<Result> InsertCompra(CrearCompraDto entity)
        {
            return compraRepository.InsertCompra(entity);
        }

        public Task<Result> UpdateCompra(CompraDto entity)
        {
            return compraRepository.UpdateCompra(entity);
        }

        public Task<Result> GetCompraDetalleById(int? Id)
        {
            return compraRepository.GetCompraDetalleById(Id);
        }
    }
}
