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
    public class CompraRepository : ICompraRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger _createLogger;
        private readonly IMapper mapper;

        public CompraRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            _createLogger = createLogger;
        }

        public async Task<Result> GetAllCompras()
        {
            Result oRespuesta = new Result();

            List<CompraDto> lstTemp = new List<CompraDto>();

            try
            {
                lstTemp = await (from p in objContext.Compras
                                 join tc in objContext.ParametrosGenerales on p.TipoComprobanteId equals tc.Id
                                 join pr in objContext.Proveedores on p.ProveedorId equals pr.Id
                                 select new CompraDto
                                 {
                                     Id = p.Id,
                                     FechaCompra = p.FechaCompra,
                                     ProveedorId = p.ProveedorId,
                                     TipoComprobanteId = p.TipoComprobanteId,
                                     NumeroComprobante = p.NumeroComprobante,
                                     Subtotal = p.Subtotal,
                                     Iva = p.Iva,
                                     Total = p.Total,
                                     IsActive = p.IsActive,
                                     NombreComprobante = tc.Nombre,
                                     NombreProveedor = pr.Nombre
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
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }
            return oRespuesta;
        }

        public async Task<Result> GetCompraById(int? Id)
        {
            Result oRespuesta = new Result();

            List<Compra> listResult = new List<Compra>();

            CompraDto lstTemp = new CompraDto();

            try
            {
                listResult = await objContext.Compras.Where(x => x.Id == Id).ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<CompraDto>(item);
                    }
                }
                else
                {
                    lstTemp = null;
                }

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
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> InsertCompra(CrearCompraDto entity)
        {
            Result oRespuesta = new Result();

            Compra lstTemp3 = new Compra();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Compra>(entity.oCompra);
                lstTemp.DetalleCompras = mapper.Map<List<DetalleCompra>>(entity.oDetalleCompra);

                lstTemp.CreatedDate = DateTime.Now;

                var validCustomers = lstTemp.DetalleCompras;

                foreach (var item in validCustomers)
                {
                    item.CreatedDate = DateTime.Now;
                }

                await objContext.AddRangeAsync(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegGuardado;
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> UpdateCompra(CompraDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Compra>(entity);

                objContext.Update(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegActualizado;
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> DeleteCompra(CompraDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Compra>(entity);

                objContext.Remove(lstTemp);

                await objContext.SaveChangesAsync();

                oRespuesta.Success = true;
                oRespuesta.Message = Constantes.msjRegEliminado;
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }

        public async Task<Result> GetCompraDetalleById(int? Id)
        {
            Result oRespuesta = new Result();

            ShowCompraDto lstTemp = new ShowCompraDto();

            try
            {
                var objCompra = await (from c in objContext.Compras
                                       join pg in objContext.ParametrosGenerales on c.TipoComprobanteId equals pg.Id
                                       join p in objContext.Proveedores on c.ProveedorId equals p.Id
                                       where c.Id == Id
                                       select new CompraDto
                                       {
                                           Id = c.Id,
                                           FechaCompra = c.FechaCompra,
                                           ProveedorId = c.ProveedorId,
                                           TipoComprobanteId = c.TipoComprobanteId,
                                           NumeroComprobante = c.NumeroComprobante,
                                           Subtotal = c.Subtotal,
                                           Iva = c.Iva,
                                           Total = c.Total,
                                           IsActive = c.IsActive,
                                           NombreComprobante = pg.Nombre,
                                           NombreProveedor = p.Nombre
                                       }).FirstAsync();

                var objDetalleCompra = await (from c in objContext.Compras
                                              join dc in objContext.DetalleCompras on c.Id equals dc.CompraId
                                              join p in objContext.Productos on dc.ProductoId equals p.Id
                                              where c.Id == Id
                                              select new DetalleCompraDto
                                              {
                                                  CompraId = dc.CompraId,
                                                  ProductoId = dc.ProductoId,
                                                  Cantidad = dc.Cantidad,
                                                  PrecioCompra = dc.PrecioCompra,
                                                  PrecioVenta = dc.PrecioVenta,
                                                  PrecioMayoreo = dc.PrecioMayoreo,
                                                  Subtotal = dc.Subtotal,
                                                  NombreProducto = p.Nombre
                                              }).ToListAsync();

                lstTemp.oCompra = mapper.Map<CompraDto>(objCompra);
                lstTemp.oDetalleCompra = mapper.Map<List<DetalleCompraDto>>(objDetalleCompra);

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
                _createLogger.LogWriteExcepcion(ex.Message);

                oRespuesta.Message = ex.Message;
            }

            return oRespuesta;
        }
    }
}
