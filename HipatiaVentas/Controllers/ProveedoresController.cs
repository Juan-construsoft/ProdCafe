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
    public class ProveedoresController : Controller
    {
        private readonly IProveedorService _proveedorService;
        private readonly IParametroGeneralService _parametroGeneralService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public ProveedoresController(IProveedorService proveedorService,
            ICreateLogger createLogger, IMapper mapper, ICommonServices commonServices, 
            IParametroGeneralService parametroGeneralService)
        {
            _proveedorService = proveedorService;
            _createLogger = createLogger;
            _mapper = mapper;
            _commonServices = commonServices;
            _parametroGeneralService = parametroGeneralService;
        }

        public async Task<ActionResult> Index()
        {
            List<ProveedorDto> lstTemp = new List<ProveedorDto>();

            var queryTable = await _proveedorService.GetAllProveedores();

            lstTemp = _mapper.Map<List<ProveedorDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProveedorDto model = new ProveedorDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _proveedorService.GetProveedorById(id);

                model = _mapper.Map<ProveedorDto>(queryTable.Data);
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listTipoDocumento = new List<SelectListItem>();
            listTipoDocumento = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoDocumento));
            ViewBag.TipoDocumento = listTipoDocumento;

            List<SelectListItem> listTipoPersona = new List<SelectListItem>();
            listTipoPersona = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoPersona));
            ViewBag.TipoPersona = listTipoPersona;

            CrearProveedorDto model = new CrearProveedorDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearProveedorDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;

                vTemp = await _proveedorService.InsertProveedor(objModel);

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
            ProveedorDto objTemp = new ProveedorDto();

            List<SelectListItem> listTipoDocumento = new List<SelectListItem>();
            listTipoDocumento = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoDocumento));
            ViewBag.TipoDocumento = listTipoDocumento;

            List<SelectListItem> listTipoPersona = new List<SelectListItem>();
            listTipoPersona = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoPersona));
            ViewBag.TipoPersona = listTipoPersona;

            var queryTable = await _proveedorService.GetProveedorById(id);

            objTemp = _mapper.Map<ProveedorDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProveedorDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _proveedorService.GetProveedorById(id);
                ProveedorDto Entity = _mapper.Map<ProveedorDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _proveedorService.UpdateProveedor(objModel);
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
            ProveedorDto objTemp = new ProveedorDto();

            var queryTable = await _proveedorService.GetProveedorById(id);

            objTemp = _mapper.Map<ProveedorDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _proveedorService.GetProveedorById(id);
                ProveedorDto Entity = _mapper.Map<ProveedorDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _proveedorService.DeleteProveedor(Entity);
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
