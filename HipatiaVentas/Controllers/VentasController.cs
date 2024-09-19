using AutoMapper;
using HipatiaVentas.Commun;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Commun.Utilidades;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static HipatiaVentas.Commun.Enumeracion;

namespace HipatiaVentas.Controllers
{
    public class VentasController : Controller
    {
        private readonly IVentaService _ventaService;
        private readonly IClienteService _clienteService;
        private readonly IProductoService _productoService;
        private readonly IParametroGeneralService _parametroGeneralService;
        private readonly ICajaService _cajaService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public VentasController(IVentaService ventaService, ICreateLogger createLogger,
            IMapper mapper, IClienteService clienteService, IProductoService productoService,
            IParametroGeneralService parametroGeneralService, ICommonServices commonServices,
            ICajaService cajaService)
        {
            _ventaService = ventaService;
            _createLogger = createLogger;
            _mapper = mapper;
            _clienteService = clienteService;
            _productoService = productoService;
            _parametroGeneralService = parametroGeneralService;
            _commonServices = commonServices;
            _cajaService = cajaService;
        }

        public async Task<IActionResult> Index()
        {
            List<VentaDto> lstTemp = new List<VentaDto>();

            try
            {
                var queryTable = await _ventaService.GetAllVentas();

                lstTemp = _mapper.Map<List<VentaDto>>(queryTable.Data);
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);
            }

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            ShowVentaDto objVenta = new ShowVentaDto();

            if (id == null)
            {
                return NotFound();
            }

            VentaDto model = new VentaDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _ventaService.GetVentaDetalleById(id);

                objVenta = _mapper.Map<ShowVentaDto>(queryTable.Data);
            }

            return View(objVenta);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listCliente = new List<SelectListItem>();
            listCliente = await _clienteService.GetSelectListItems();
            ViewBag.Cliente = listCliente;

            List<SelectListItem> listProducto = new List<SelectListItem>();
            listProducto = await _productoService.GetSelectListItemsVenta();
            ViewBag.Producto = listProducto;

            List<SelectListItem> listTipoComprobante = new List<SelectListItem>();
            listTipoComprobante = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoComprobante));
            ViewBag.TipoComprobante = listTipoComprobante;

            List<SelectListItem> listCaja = new List<SelectListItem>();
            listCaja = await _cajaService.GetSelectListItems();
            ViewBag.Caja = listCaja;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearVentaDto objModel)
        {
            Result vTemp = new Result();

            ProductoDto model = new ProductoDto();

            try
            {
                vTemp = await _ventaService.InsertVenta(objModel);

                if (vTemp.Success)
                {
                    foreach (var item in objModel.oDetalleVenta)
                    {
                        model = null;

                        var queryTable = await _productoService.GetProductoById(item.ProductoId);

                        if (queryTable.Data != null)
                        {
                            model = _mapper.Map<ProductoDto>(queryTable.Data);
                            model.Stock = model.Stock - item.Cantidad;

                            model.ModifiedUser = User.Identity.Name;
                            model.ModifiedDate = DateTime.Now;

                            vTemp = await _productoService.UpdateProducto(model);
                        }
                    }
                }

                if (vTemp.Success)
                    TempData["Mensaje"] = _commonServices.ShowAlert(Alerts.Success, vTemp.Message);
                else
                    TempData["Mensaje"] = _commonServices.ShowAlert(Alerts.Danger, vTemp.Message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<JsonResult> ListaProductos()
        {
            var oLista = await _productoService.GetAllProductos();
            return Json(new { data = oLista });
        }

        [HttpPost]
        public async Task<ActionResult> ProductoById([FromBody] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductoPrecioDto model = new ProductoPrecioDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _productoService.GetProductoByPrecioId(id);

                model = _mapper.Map<ProductoPrecioDto>(queryTable.Data);
            }

            return Json(new { mensage = "exitoso", data = model });            
        }
    }
}
