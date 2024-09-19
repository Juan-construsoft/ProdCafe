using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class CajaService : ICajaService
    {
        private readonly ICajaRepository cajaRepository;
        private readonly IMapper _mapper;

        public CajaService(ICajaRepository _cajaRepository, IMapper mapper)
        {
            this.cajaRepository = _cajaRepository;
            _mapper = mapper;
        }

        public Task<Result> DeleteCaja(CajaDto entity)
        {
            return cajaRepository.DeleteCaja(entity);
        }

        public Task<Result> GetCajaById(int? Id)
        {
            return cajaRepository.GetCajaById(Id);
        }

        public Task<Result> GetAllCajas()
        {
            return cajaRepository.GetAllCajas();
        }

        public Task<Result> InsertCaja(CrearCajaDto entity)
        {
            return cajaRepository.InsertCaja(entity);
        }

        public Task<Result> UpdateCaja(CajaDto entity)
        {
            return cajaRepository.UpdateCaja(entity);
        }

        public async Task<List<SelectListItem>> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();
            List<CajaDto> elements = new List<CajaDto>();

            var listResult = await cajaRepository.GetAllCajas();

            if (listResult.Data != null)
            {
                var objList = _mapper.Map<List<CajaDto>>(listResult.Data);

                foreach (var element in objList)
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

