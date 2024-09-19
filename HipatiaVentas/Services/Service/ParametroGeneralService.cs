using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class ParametroGeneralService : IParametroGeneralService
    {
        private readonly IParametroGeneralRepository _parametroGeneralRepository;
        private readonly IMapper _mapper;

        public ParametroGeneralService(IParametroGeneralRepository parametroGeneralRepository, IMapper mapper)
        {
            _parametroGeneralRepository = parametroGeneralRepository;
            _mapper = mapper;
        }

        public Task<Result> DeleteParametroGeneral(ParametroGeneralDto entity)
        {
            return _parametroGeneralRepository.DeleteParametroGeneral(entity);
        }

        public Task<Result> GetParametroGeneralById(int? Id)
        {
            return _parametroGeneralRepository.GetParametroGeneralById(Id);
        }

        public Task<Result> GetAllParametroGenerales()
        {
            return _parametroGeneralRepository.GetAllParametroGenerales();
        }

        public Task<Result> InsertParametroGeneral(CrearParametroGeneralDto entity)
        {
            return _parametroGeneralRepository.InsertParametroGeneral(entity);
        }

        public Task<Result> UpdateParametroGeneral(ParametroGeneralDto entity)
        {
            return _parametroGeneralRepository.UpdateParametroGeneral(entity);
        }

        public Task<Result> GetParametroGeneralByCategoria(int Id)
        {
            return _parametroGeneralRepository.GetParametroGeneralByCategoria(Id);
        }

        public async Task<List<SelectListItem>> GetSelectListItems(int vCategoria)
        {
            var selectList = new List<SelectListItem>();
            List<ParametroGeneralDto> elements = new List<ParametroGeneralDto>();

            var listResult = await _parametroGeneralRepository.GetParametroGeneralByCategoria(vCategoria);

            if (listResult.Data != null)
            {
                var objList = _mapper.Map<List<ParametroGeneralDto>>(listResult.Data);

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
