using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Repositories.Repository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository ventaRepository;

        public VentaService(IVentaRepository _ventaRepository)
        {
            this.ventaRepository = _ventaRepository;
        }

        public Task<Result> DeleteVenta(VentaDto entity)
        {
            return ventaRepository.DeleteVenta(entity);
        }

        public Task<Result> GetVentaById(int Id)
        {
            return ventaRepository.GetVentaById(Id);
        }

        public Task<Result> GetAllVentas()
        {
            return ventaRepository.GetAllVentas();
        }

        public Task<Result> InsertVenta(CrearVentaDto entity)
        {
            return ventaRepository.InsertVenta(entity);
        }

        public Task<Result> UpdateVenta(VentaDto entity)
        {
            return ventaRepository.UpdateVenta(entity);
        }

        public Task<Result> GetVentaDetalleById(int? Id)
        {
            return ventaRepository.GetVentaDetalleById(Id);
        }
    }
}
