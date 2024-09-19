using AutoMapper;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Data;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Repositories.IRepository;

namespace HipatiaVentas.Repositories.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext objContext;

        private readonly ICreateLogger _createLogger;

        private readonly IMapper mapper;

        public DashboardRepository(ApplicationDbContext _objContext, IMapper _mapper)
        {
            this.objContext = _objContext;
            this.mapper = _mapper;
        }

        public async Task<Result> GetAllDashboard()
        {
            Result oRespuesta = new Result();

            List<DashboardDto> lstTemp = new List<DashboardDto>();
            DashboardDto objTemp = new DashboardDto();

            DateTime vFecha = DateTime.Now;
            DateTime vFecha2 = DateTime.Now;
            vFecha = vFecha.AddDays(-30);
            vFecha2 = vFecha2.AddDays(-7);

            try
            {
                //objTemp.TotalVentas = await objContext.Ventas.Where(v => v.FechaRegistro >= vFecha).CountAsync();
                //objTemp.TotalIngresos = (float)await objContext.Ventas.Where(v => v.FechaRegistro >= vFecha).SumAsync(v => v.Total);
                //objTemp.TotalProductos = await objContext.Productos.CountAsync();
                //objTemp.TotalCategorias = await objContext.Categorias.CountAsync();

                //objTemp.ProductosVendidos = (from p in objContext.Productos
                //                             join d in objContext.DetalleVentas on p.Id equals d.IdProducto
                //                             group p by p.Descripcion into g
                //                             orderby g.Count() ascending
                //                             select new ProductoVendidosDto { Producto = g.Key, Total = g.Count().ToString() }).Take(4).ToList();

                //objTemp.VentasporDias = (from v in objContext.Ventas
                //                         where v.FechaRegistro >= vFecha2.Date
                //                         group v by v.FechaRegistro into g
                //                         orderby g.Key ascending
                //                         select new VentasDiasDto { Fecha = g.Key.ToString("dd/MM/yyyy"), Total = g.Count().ToString() }).ToList();

                //if (objTemp != null)
                //{
                //    oRespuesta.Success = true;
                //    oRespuesta.Data = lstTemp;
                //}
                //else
                //{
                //    oRespuesta.Success = false;
                //    oRespuesta.Message = Constantes.msjNoHayRegistros;
                //}
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
