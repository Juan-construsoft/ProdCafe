using AutoMapper;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HipatiaVentas.Services.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository productoRepository;
        private readonly IMapper mapper;

        public ProductoService(IProductoRepository _productoRepository, IMapper _mapper)
        {
            this.productoRepository = _productoRepository;
            this.mapper = _mapper;
        }

        public Task<Result> DeleteProducto(ProductoDto entity)
        {
            return productoRepository.DeleteProducto(entity);
        }

        public Task<Result> GetProductoById(int? Id)
        {
            return productoRepository.GetProductoById(Id);
        }

        public Task<Result> GetAllProductos()
        {
            return productoRepository.GetAllProductos();
        }

        public Task<Result> InsertProducto(CrearProductoDto entity)
        {
            return productoRepository.InsertProducto(entity);
        }

        public Task<Result> UpdateProducto(ProductoDto entity)
        {
            return productoRepository.UpdateProducto(entity);
        }

        public async Task<List<SelectListItem>> GetSelectListItemsVenta()
        {
            var selectList = new List<SelectListItem>();
            List<ProductoDto> elements = new List<ProductoDto>();

            var listResult = await productoRepository.GetAllProductos();

            if (listResult.Data != null)
            {
                elements = mapper.Map<List<ProductoDto>>(listResult.Data).Where(x => x.Stock > 0).ToList();

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

        public async Task<List<SelectListItem>> GetSelectListItemsCompra()
        {
            var selectList = new List<SelectListItem>();
            List<ProductoDto> elements = new List<ProductoDto>();

            var listResult = await productoRepository.GetAllProductos();

            if (listResult.Data != null)
            {
                elements = mapper.Map<List<ProductoDto>>(listResult.Data).ToList();

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

        public Task<Result> GetProductoByPrecioId(int? Id)
        {
            return productoRepository.GetProductoByPrecioId(Id);
        }
    }
}
