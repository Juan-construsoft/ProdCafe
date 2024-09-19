using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class DetalleCompraService : IDetalleCompraService
    {
        private readonly IDetalleCompraRepository detallecompraRepository;

        public DetalleCompraService(IDetalleCompraRepository _detallecompraRepository)
        {
            this.detallecompraRepository = _detallecompraRepository;
        }

        public Task<Result> DeleteDetalleCompra(DetalleCompraDto entity)
        {
            return detallecompraRepository.DeleteDetalleCompra(entity);
        }

        public Task<Result> GetDetalleCompraById(int Id)
        {
            return detallecompraRepository.GetDetalleCompraById(Id);
        }

        public Task<Result> GetAllDetalleCompras()
        {
            return detallecompraRepository.GetAllDetalleCompras();
        }

        public Task<Result> InsertDetalleCompra(CrearDetalleCompraDto entity)
        {
            return detallecompraRepository.InsertDetalleCompra(entity);
        }

        public Task<Result> UpdateDetalleCompra(DetalleCompraDto entity)
        {
            return detallecompraRepository.UpdateDetalleCompra(entity);
        }
    }
}

