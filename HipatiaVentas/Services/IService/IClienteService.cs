using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.IService
{
    public interface IClienteService
    {
        Task<Result> GetAllClientes();
        Task<Result> GetClienteById(int? Id);
        Task<Result> InsertCliente(CrearClienteDto entity);
        Task<Result> UpdateCliente(ClienteDto entity);
        Task<Result> DeleteCliente(ClienteDto entity);

        Task<List<SelectListItem>> GetSelectListItems();
    }
}

