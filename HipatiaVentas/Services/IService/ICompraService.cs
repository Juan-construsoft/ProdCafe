using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Services.IService
{
    public interface ICompraService
    {
        Task<Result> GetAllCompras();
        Task<Result> GetCompraById(int? Id);
        Task<Result> InsertCompra(CrearCompraDto entity);
        Task<Result> UpdateCompra(CompraDto entity);
        Task<Result> DeleteCompra(CompraDto entity);

        Task<Result> GetCompraDetalleById(int? Id);
    }
}
