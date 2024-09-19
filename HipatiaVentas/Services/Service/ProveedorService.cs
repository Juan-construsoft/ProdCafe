using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository proveedorRepository;
        private readonly IMapper mapper;

        public ProveedorService(IProveedorRepository _proveedorRepository, IMapper _mapper)
        {
            this.proveedorRepository = _proveedorRepository;
            this.mapper = _mapper;
        }

        public Task<Result> DeleteProveedor(ProveedorDto entity)
        {
            return proveedorRepository.DeleteProveedor(entity);
        }

        public Task<Result> GetProveedorById(int? Id)
        {
            return proveedorRepository.GetProveedorById(Id);
        }

        public Task<Result> GetAllProveedores()
        {
            return proveedorRepository.GetAllProveedores();
        }

        public Task<Result> InsertProveedor(CrearProveedorDto entity)
        {
            return proveedorRepository.InsertProveedor(entity);
        }

        public Task<Result> UpdateProveedor(ProveedorDto entity)
        {
            return proveedorRepository.UpdateProveedor(entity);
        }

        public async Task<List<SelectListItem>> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();

            List<ProveedorDto> elements = new List<ProveedorDto>();

            var listResult = await proveedorRepository.GetAllProveedores();

            if (listResult.Data != null)
            {
                elements = mapper.Map<List<ProveedorDto>>(listResult.Data);

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
