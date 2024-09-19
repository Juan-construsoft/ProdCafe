using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly IDetalleVentaRepository detalleVentaRepository;

        public DetalleVentaService(IDetalleVentaRepository _detalleVentaRepository)
        {
            this.detalleVentaRepository = _detalleVentaRepository;
        }

        public Task<Result> DeleteDetalleVenta(DetalleVentaDto entity)
        {
            return detalleVentaRepository.DeleteDetalleVenta(entity);
        }

        public Task<Result> GetDetalleVentaById(int Id)
        {
            return detalleVentaRepository.GetDetalleVentaById(Id);
        }

        public Task<Result> GetAllDetalleVentas()
        {
            return detalleVentaRepository.GetAllDetalleVentas();
        }

        public Task<Result> InsertDetalleVenta(CrearDetalleVentaDto entity)
        {
            return detalleVentaRepository.InsertDetalleVenta(entity);
        }

        public Task<Result> UpdateDetalleVenta(DetalleVentaDto entity)
        {
            return detalleVentaRepository.UpdateDetalleVenta(entity);
        }
    }
}
