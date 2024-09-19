using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;

namespace HipatiaVentas.Services.Service
{
    public class MovimientoCajaService : IMovimientoCajaService
    {
        private readonly IMovimientoCajaRepository movimientocajaRepository;

        public MovimientoCajaService(IMovimientoCajaRepository _movimientocajaRepository)
        {
            this.movimientocajaRepository = _movimientocajaRepository;
        }

        public Task<Result> DeleteMovimientoCaja(MovimientoCajaDto entity)
        {
            return movimientocajaRepository.DeleteMovimientoCaja(entity);
        }

        public Task<Result> GetMovimientoCajaById(int Id)
        {
            return movimientocajaRepository.GetMovimientoCajaById(Id);
        }

        public Task<Result> GetAllMovimientoCajas()
        {
            return movimientocajaRepository.GetAllMovimientoCajas();
        }

        public Task<Result> InsertMovimientoCaja(CrearMovimientoCajaDto entity)
        {
            return movimientocajaRepository.InsertMovimientoCaja(entity);
        }

        public Task<Result> UpdateMovimientoCaja(MovimientoCajaDto entity)
        {
            return movimientocajaRepository.UpdateMovimientoCaja(entity);
        }
    }
}

