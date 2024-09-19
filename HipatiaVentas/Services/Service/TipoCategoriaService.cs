using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Repositories.Repository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class TipoCategoriaService : ITipoCategoriaService
    {
        private readonly ITipoCategoriaRepository tipoCategoriaRepository;
        private readonly IMapper _mapper;

        public TipoCategoriaService(ITipoCategoriaRepository _tipoCategoriaRepository, IMapper mapper)
        {
            this.tipoCategoriaRepository = _tipoCategoriaRepository;
            _mapper = mapper;
        }

        public Task<Result> DeleteTipoCategoria(TipoCategoriaDto entity)
        {
            return tipoCategoriaRepository.DeleteTipoCategoria(entity);
        }

        public Task<Result> GetTipoCategoriaById(int? Id)
        {
            return tipoCategoriaRepository.GetTipoCategoriaById(Id);
        }

        public Task<Result> GetAllTipoCategorias()
        {
            return tipoCategoriaRepository.GetAllTipoCategorias();
        }

        public Task<Result> InsertTipoCategoria(CrearTipoCategoriaDto entity)
        {
            return tipoCategoriaRepository.InsertTipoCategoria(entity);
        }

        public Task<Result> UpdateTipoCategoria(TipoCategoriaDto entity)
        {
            return tipoCategoriaRepository.UpdateTipoCategoria(entity);
        }

        public async Task<List<SelectListItem>> GetSelectListItems()
        {
            var selectList = new List<SelectListItem>();
            List<TipoCategoriaDto> elements = new List<TipoCategoriaDto>();

            var listResult = await tipoCategoriaRepository.GetAllTipoCategorias();

            if (listResult.Data != null)
            {
                var objList = _mapper.Map<List<TipoCategoriaDto>>(listResult.Data);

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

