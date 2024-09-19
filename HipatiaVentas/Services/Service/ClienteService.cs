using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository proveedorRepository;
        private readonly IMapper mapper;

        public ClienteService(IClienteRepository _proveedorRepository, IMapper _mapper)
        {
            this.proveedorRepository = _proveedorRepository;
            this.mapper = _mapper;
        }

        public Task<Result> DeleteCliente(ClienteDto entity)
        {
            return proveedorRepository.DeleteCliente(entity);
        }

        public Task<Result> GetClienteById(int? Id)
        {
            return proveedorRepository.GetClienteById(Id);
        }

        public Task<Result> GetAllClientes()
        {
            return proveedorRepository.GetAllClientes();
        }

        public Task<Result> InsertCliente(CrearClienteDto entity)
        {
            return proveedorRepository.InsertCliente(entity);
        }

        public Task<Result> UpdateCliente(ClienteDto entity)
        {
            return proveedorRepository.UpdateCliente(entity);
        }

        public async Task<List<SelectListItem>> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            List<ClienteDto> elements = new List<ClienteDto>();

            var listResult = await proveedorRepository.GetAllClientes();

            if (listResult.Data != null)
            {
                elements = mapper.Map<List<ClienteDto>>(listResult.Data);

                foreach (var element in elements)
                {
                    if (element.IsActive == true)
                        selectList.Add(new SelectListItem
                        {
                            Value = element.Id.ToString(),
                            Text = element.Nombre
                        });
                }
            }
            else
            {
                elements = null;
            }

            return selectList;
        }
    }
}
