using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Commun.Utilidades;
using HipatiaVentas.Repositories.IRepository;
using HipatiaVentas.Repositories.Repository;
using HipatiaVentas.Services.IService;
using HipatiaVentas.Services.Service;

namespace HipatiaVentas.DependencyInjection
{
    public static class InyectarDependencia
    {
        public static void InyeccionServicios(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped(typeof(IBackOfficeRepository), typeof(BackOfficeRepository));
            services.AddScoped(typeof(ICajaRepository), typeof(CajaRepository));
            services.AddScoped(typeof(IClienteRepository), typeof(ClienteRepository));
            services.AddScoped(typeof(ICompraRepository), typeof(CompraRepository));
            services.AddScoped(typeof(IDashboardRepository), typeof(DashboardRepository));
            services.AddScoped(typeof(IDepartamentoRepository), typeof(DepartamentoRepository));
            services.AddScoped(typeof(IDetalleCompraRepository), typeof(DetalleCompraRepository));
            services.AddScoped(typeof(IDetalleVentaRepository), typeof(DetalleVentaRepository));
            services.AddScoped(typeof(IMovimientoCajaRepository), typeof(MovimientoCajaRepository));
            services.AddScoped(typeof(IMunicipioRepository), typeof(MunicipioRepository));
            services.AddScoped(typeof(IParametroGeneralRepository), typeof(ParametroGeneralRepository));
            services.AddScoped(typeof(IProductoRepository), typeof(ProductoRepository));
            services.AddScoped(typeof(IProveedorRepository), typeof(ProveedorRepository));
            services.AddScoped(typeof(IRegistroTostionRepository), typeof(RegistroTostionRepository));
            services.AddScoped(typeof(ITipoCategoriaRepository), typeof(TipoCategoriaRepository));
            services.AddScoped(typeof(IVentaRepository), typeof(VentaRepository));
            services.AddScoped(typeof(IRegistroCatacionRepository), typeof(RegistroCatacionRepository));

            //*******************************************************************************************

            services.AddTransient<IAlmacenamientoAzureStorage, AlmacenamientoAzureStorage>();
            services.AddTransient<IAuthToken, AuthToken>();

            services.AddScoped(typeof(IBackOfficeService), typeof(BackOfficeService));
            services.AddScoped(typeof(ICajaService), typeof(CajaService));
            services.AddScoped(typeof(IClienteService), typeof(ClienteService));
            services.AddScoped(typeof(ICompraService), typeof(CompraService));
            services.AddScoped(typeof(IDashboardService), typeof(DashboardService));
            services.AddScoped(typeof(IDepartamentoService), typeof(DepartamentoService));
            services.AddScoped(typeof(IDetalleCompraService), typeof(DetalleCompraService));
            services.AddScoped(typeof(IDetalleVentaService), typeof(DetalleVentaService));
            services.AddScoped(typeof(IMovimientoCajaService), typeof(MovimientoCajaService));
            services.AddScoped(typeof(IMunicipioService), typeof(MunicipioService));
            services.AddScoped(typeof(IParametroGeneralService), typeof(ParametroGeneralService));
            services.AddScoped(typeof(IProductoService), typeof(ProductoService));
            services.AddScoped(typeof(IProveedorService), typeof(ProveedorService));
            services.AddScoped(typeof(IRegistroTostionService), typeof(RegistroTostionService));
            services.AddScoped(typeof(ITipoCategoriaService), typeof(TipoCategoriaService));
            services.AddScoped(typeof(IVentaService), typeof(VentaService));
            services.AddScoped(typeof(IRegistroCatacionService), typeof(RegistroCatacionService));

            services.AddScoped(typeof(ICreateLogger), typeof(CreateLogger));
            services.AddTransient<IUtilidades, Utilidades>();
            services.AddTransient<ICommonServices, CommonServices>();
        }
    }
}
