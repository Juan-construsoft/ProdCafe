using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;

namespace HipatiaVentas.Repositories.IRepository
{
    public interface IClienteRepository
    {
        Task<Result> GetAllClientes();
        Task<Result> GetClienteById(int? Id);
        Task<Result> InsertCliente(CrearClienteDto entity);
        Task<Result> UpdateCliente(ClienteDto entity);
        Task<Result> DeleteCliente(ClienteDto entity);
    }
}
