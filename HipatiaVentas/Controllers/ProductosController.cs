using AutoMapper;
using HipatiaVentas.Commun;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Commun.Utilidades;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using HipatiaVentas.Services.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static HipatiaVentas.Commun.Enumeracion;

namespace HipatiaVentas.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IParametroGeneralService _parametroGeneralService;
        private readonly IProveedorService _proveedorService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public ProductosController(IProductoService productoService, ICreateLogger createLogger,
            IMapper mapper, IParametroGeneralService parametroGeneralService,
            ICommonServices commonServices, IProveedorService proveedorService)
        {
            _productoService = productoService;
            _createLogger = createLogger;
            _mapper = mapper;
            _parametroGeneralService = parametroGeneralService;
            _commonServices = commonServices;
            _proveedorService = proveedorService;
        }

        public async Task<ActionResult> Index()
        {
            List<ProductoDto> lstTemp = new List<ProductoDto>();

            var queryTable = await _productoService.GetAllProductos();

            lstTemp = _mapper.Map<List<ProductoDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductoDto model = new ProductoDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _productoService.GetProductoById(id);

                model = _mapper.Map<ProductoDto>(queryTable.Data);
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listTipoCategoria = new List<SelectListItem>();
            listTipoCategoria = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Categoria));
            ViewBag.TipoCategoria = listTipoCategoria;

            List<SelectListItem> listPresentacion = new List<SelectListItem>();
            listPresentacion = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Presentacion));
            ViewBag.Presentacion = listPresentacion;

            List<SelectListItem> listMarca = new List<SelectListItem>();
            listMarca = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Marca));
            ViewBag.Marca = listMarca;

            CrearProductoDto model = new CrearProductoDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearProductoDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;
                objModel.Stock = 0;

                if (objModel.Foto == null)
                    objModel.Foto = "";

                vTemp = await _productoService.InsertProducto(objModel);

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

        public async Task<IActionResult> Edit(int id)
        {
            ProductoDto objTemp = new ProductoDto();

            List<SelectListItem> listTipoCategoria = new List<SelectListItem>();
            listTipoCategoria = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Categoria));
            ViewBag.TipoCategoria = listTipoCategoria;

            List<SelectListItem> listPresentacion = new List<SelectListItem>();
            listPresentacion = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Presentacion));
            ViewBag.Presentacion = listPresentacion;

            List<SelectListItem> listMarca = new List<SelectListItem>();
            listMarca = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Marca));
            ViewBag.Marca = listMarca;

            var queryTable = await _productoService.GetProductoById(id);

            objTemp = _mapper.Map<ProductoDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductoDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _productoService.GetProductoById(id);
                ProductoDto Entity = _mapper.Map<ProductoDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _productoService.UpdateProducto(objModel);
                }

                if (vTemp.Success)
                    TempData["Mensaje"] = _commonServices.ShowAlert(Alerts.Success, vTemp.Message);
                else
                    TempData["Mensaje"] = _commonServices.ShowAlert(Alerts.Danger, vTemp.Message);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(objModel);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            ProductoDto objTemp = new ProductoDto();

            var queryTable = await _productoService.GetProductoById(id);

            objTemp = _mapper.Map<ProductoDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _productoService.GetProductoById(id);
                ProductoDto Entity = _mapper.Map<ProductoDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _productoService.DeleteProducto(Entity);
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
    }
}
