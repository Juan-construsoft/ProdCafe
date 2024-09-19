using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface ICompraRepository
    {
        Task<Result> GetAllCompras();
        Task<Result> GetCompraById(int? Id);
        Task<Result> InsertCompra(CrearCompraDto entity);
        Task<Result> UpdateCompra(CompraDto entity);
        Task<Result> DeleteCompra(CompraDto entity);

        Task<Result> GetCompraDetalleById(int? Id);
    }
}
