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
    public class ComprasController : Controller
    {
        private readonly ICompraService _compraService;
        private readonly IProveedorService _proveedorService;
        private readonly IProductoService _productoService;
        private readonly IParametroGeneralService _parametroGeneralService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public ComprasController(ICompraService compraService, ICreateLogger createLogger,
            IMapper mapper, IProveedorService proveedorService, IProductoService productoService,
            IParametroGeneralService parametroGeneralService, ICommonServices commonServices)
        {
            _compraService = compraService;
            _createLogger = createLogger;
            _mapper = mapper;
            _proveedorService = proveedorService;
            _productoService = productoService;
            _parametroGeneralService = parametroGeneralService;
            _commonServices = commonServices;
        }

        public async Task<IActionResult> Index()
        {
            List<CompraDto> lstTemp = new List<CompraDto>();

            try
            {
                var queryTable = await _compraService.GetAllCompras();

                lstTemp = _mapper.Map<List<CompraDto>>(queryTable.Data);
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);
            }

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            ShowCompraDto objCompra = new ShowCompraDto();

            if (id == null)
            {
                return NotFound();
            }

            CompraDto model = new CompraDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _compraService.GetCompraDetalleById(id);

                objCompra = _mapper.Map<ShowCompraDto>(queryTable.Data);               
            }

            return View(objCompra);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listProveedor = new List<SelectListItem>();
            listProveedor = await _proveedorService.GetSelectListItems();
            ViewBag.Proveedor = listProveedor;

            List<SelectListItem> listProducto = new List<SelectListItem>();
            listProducto = await _productoService.GetSelectListItemsCompra();
            ViewBag.Producto = listProducto;

            List<SelectListItem> listTipoComprobante = new List<SelectListItem>();
            listTipoComprobante = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoComprobante));
            ViewBag.TipoComprobante = listTipoComprobante;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearCompraDto objModel)
        {
            Result vTemp = new Result();

            ProductoDto model = new ProductoDto();

            try
            {
                vTemp = await _compraService.InsertCompra(objModel);

                if (vTemp.Success)
                {
                    foreach (var item in objModel.oDetalleCompra)
                    {
                        model = null;

                        var queryTable = await _productoService.GetProductoById(item.ProductoId);

                        if (queryTable.Data != null)
                        {
                            model = _mapper.Map<ProductoDto>(queryTable.Data);
                            model.Stock = model.Stock + item.Cantidad;

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
    }
}
