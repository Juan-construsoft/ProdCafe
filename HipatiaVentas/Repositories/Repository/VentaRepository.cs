using AutoMapper;
using HipatiaVentas.Commun;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Data;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Repositories.Repository
{
    public class VentaRepository : IVentaRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger _createLogger;

        private readonly IMapper mapper;

        public VentaRepository(ApplicationDbContext _objContext, IMapper _mapper, ICreateLogger createLogger)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
            _createLogger = createLogger;
        }

        public async Task<Result> GetAllVentas()
        {
            Result oRespuesta = new Result();

            List<VentaDto> lstTemp = new List<VentaDto>();

            try
            {
                lstTemp = await (from p in objContext.Ventas
                                 join tc in objContext.ParametrosGenerales on p.TipoComprobanteId equals tc.Id
                                 join cl in objContext.Clientes on p.ClienteId equals cl.Id
                                 join ca in objContext.Cajas on p.CajaId equals ca.Id
                                 select new VentaDto
                                 {
                                     Id = p.Id,
                                     FechaVenta = p.FechaVenta,
                                     ClienteId = p.ClienteId,
                                     CajaId = p.CajaId,
                                     TipoComprobanteId = p.TipoComprobanteId,
                                     NumeroComprobante = p.NumeroComprobante,
                                     Subtotal = p.Subtotal,
                                     Iva = p.Iva,
                                     Total = p.Total,
                                     IsActive = p.IsActive,
                                     NombreComprobante = tc.Nombre,
                                     NombreCliente = cl.Nombre,
                                     NombreCaja = ca.Nombre
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

        public async Task<Result> GetVentaById(int Id)
        {
            Result oRespuesta = new Result();

            List<Venta> listResult = new List<Venta>();

            VentaDto lstTemp = new VentaDto();

            try
            {
                listResult = await objContext.Ventas.Where(x => x.Id == Id).ToListAsync();

                if (listResult.Count > 0)
                {
                    foreach (var item in listResult)
                    {
                        lstTemp = mapper.Map<VentaDto>(item);
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

        public async Task<Result> InsertVenta(CrearVentaDto entity)
        {
            Result oRespuesta = new Result();

            Venta lstTemp3 = new Venta();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Venta>(entity.oVenta);
                lstTemp.DetalleVentas = mapper.Map<List<DetalleVenta>>(entity.oDetalleVenta);

                lstTemp.CreatedDate = DateTime.Now;

                var validCustomers = lstTemp.DetalleVentas;

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

        public async Task<Result> UpdateVenta(VentaDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Venta>(entity);

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

        public async Task<Result> DeleteVenta(VentaDto entity)
        {
            Result oRespuesta = new Result();

            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                var lstTemp = mapper.Map<Venta>(entity);

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

        public async Task<Result> GetVentaDetalleById(int? Id)
        {
            Result oRespuesta = new Result();

            ShowVentaDto lstTemp = new ShowVentaDto();

            try
            {
                var objVenta = await (from v in objContext.Ventas
                                      join pg in objContext.ParametrosGenerales on v.TipoComprobanteId equals pg.Id
                                      join cl in objContext.Clientes on v.ClienteId equals cl.Id
                                      join ca in objContext.Cajas on v.CajaId equals ca.Id
                                      where v.Id == Id
                                      select new VentaDto
                                      {
                                          Id = v.Id,
                                          FechaVenta = v.FechaVenta,
                                          ClienteId = v.ClienteId,
                                          CajaId = v.CajaId,
                                          TipoComprobanteId = v.TipoComprobanteId,
                                          NumeroComprobante = v.NumeroComprobante,
                                          Subtotal = v.Subtotal,
                                          Iva = v.Iva,
                                          Total = v.Total,
                                          IsActive = v.IsActive,
                                          NombreComprobante = pg.Nombre,
                                          NombreCliente = cl.Nombre,
                                          NombreCaja = ca.Nombre
                                      }).FirstAsync();

                var objDetalleVenta = await (from v in objContext.Ventas
                                             join dv in objContext.DetalleVentas on v.Id equals dv.VentaId
                                             join p in objContext.Productos on dv.ProductoId equals p.Id
                                             where v.Id == Id
                                             select new DetalleVentaDto
                                             {
                                                 VentaId = dv.VentaId,
                                                 ProductoId = dv.ProductoId,
                                                 Cantidad = dv.Cantidad,
                                                 PrecioVenta = dv.PrecioVenta,
                                                 Descuento = dv.Descuento,
                                                 Subtotal = dv.Subtotal,
                                                 NombreProducto = p.Nombre       
                                             }).ToListAsync();

                lstTemp.oVenta = mapper.Map<VentaDto>(objVenta);
                lstTemp.oDetalleVenta = mapper.Map<List<DetalleVentaDto>>(objDetalleVenta);

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
