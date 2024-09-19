using AutoMapper;
using HipatiaVentas.Commun;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Data;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;

namespace HipatiaVentas.Repositories.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger createLogger;
        private readonly IMapper mapper;

        public ProductoRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger _createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            this.createLogger = _createLogger;
        }

        public async Task<Result> GetAllProductos()
        {
            Result oRespuesta = new Result();

            List<ProductoDto> lstTemp = new List<ProductoDto>();

            try
            {
                lstTemp = await (from p in objContext.Productos
                                 join ma in objContext.ParametrosGenerales on p.MarcaId equals ma.Id
                                 join pr in objContext.ParametrosGenerales on p.PresentacionId equals pr.Id
                                 join ca in objContext.ParametrosGenerales on p.CategoriaId equals ca.Id
                                 select new ProductoDto
                                 {
                                     Id = p.Id,
                                     Codigo = p.Codigo,
                                     Nombre = p.Nombre,
                                     Stock = p.Stock,
                                     Descripcion = p.Descripcion,
                                     Vencimiento = p.Vencimiento,
                                     FechaVencimiento = p.FechaVencimiento,
                                     Foto = p.Foto,
                                     MarcaId = p.MarcaId,
                                     PresentacionId = p.PresentacionId,
                                     CategoriaId = p.CategoriaId,
                                     IsActive = p.IsActive,
                                     NombreMarca = ma.Nombre,
                                     NombrePresentacion = pr.Nombre,
                                     NombreCategoria = ca.Nombre
                                 }).ToListAsync();

                if (lstTemp.Count > 0)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> GetProductoById(int? Id)
        {
            Result oRespuesta = new Result();

            ProductoDto objTemp = new ProductoDto();

            try
            {
                var objResult = await objContext.Productos.Where(x => x.Id == Id).AsNoTracking().FirstOrDefaultAsync();

                if (objResult != null)
                {
                    objTemp = mapper.Map<ProductoDto>(objResult);

                    oRespuesta.Success = true;
                    oRespuesta.Data = objTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> InsertProducto(CrearProductoDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Producto>(entity);

                await objContext.AddAsync(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegGuardado;
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> UpdateProducto(ProductoDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Producto>(entity);

                objContext.Update(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegActualizado;
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> DeleteProducto(ProductoDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Producto>(entity);

                objContext.Remove(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegEliminado;
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> GetProductoByPrecioId(int? Id)
        {
            Result oRespuesta = new Result();

            ProductoPrecioDto lstTemp = new ProductoPrecioDto();

            try
            {
                lstTemp = await (from p in objContext.Productos
                                 join dc in objContext.DetalleCompras on p.Id equals dc.ProductoId
                                 where p.Id == Id
                                 select new ProductoPrecioDto
                                 {
                                     Stock = p.Stock,
                                     PrecioVenta = dc.PrecioVenta
                                 }).FirstAsync();

                if (lstTemp != null)
                {
                    oRespuesta.Success = true;
                    oRespuesta.Data = lstTemp;
                }
                else
                {
                    oRespuesta.Success = false;
                    oRespuesta.Message = Constantes.msjNoHayRegistros;
                }
            }
            catch (Exception ex)
            {
                createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }
    }
}
