using AutoMapper;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Commun.Utilidades;
using HipatiaVentas.Commun;
using HipatiaVentas.Data;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static HipatiaVentas.Commun.Enumeracion;

namespace HipatiaVentas.Controllers
{
    public class RegistroCatacionesController : Controller
    {
        private readonly IRegistroCatacionService _registroCatacionService;
        private readonly IParametroGeneralService _parametroGeneralService;       
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public RegistroCatacionesController(IRegistroCatacionService registroCatacionService, 
            ICreateLogger createLogger,
            IMapper mapper, IParametroGeneralService parametroGeneralService,
            ICommonServices commonServices)
        {
            _registroCatacionService = registroCatacionService;
            _createLogger = createLogger;
            _mapper = mapper;
            _parametroGeneralService = parametroGeneralService;
            _commonServices = commonServices;            
        }

        public async Task<ActionResult> Index()
        {
            List<RegistroCatacionDto> lstTemp = new List<RegistroCatacionDto>();

            var queryTable = await _registroCatacionService.GetAllRegistroCataciones();

            lstTemp = _mapper.Map<List<RegistroCatacionDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RegistroCatacionDto model = new RegistroCatacionDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _registroCatacionService.GetRegistroCatacionById(id);

                model = _mapper.Map<RegistroCatacionDto>(queryTable.Data);
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listVariedad = new List<SelectListItem>();
            listVariedad = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Variedad));
            ViewBag.Variedad = listVariedad;

            List<SelectListItem> listTipoLavado = new List<SelectListItem>();
            listTipoLavado = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoLavado));
            ViewBag.TipoLavado = listTipoLavado;           

            CrearRegistroCatacionDto model = new CrearRegistroCatacionDto();

            model.FechaPrueba= DateTime.Now;    

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearRegistroCatacionDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;               

                vTemp = await _registroCatacionService.InsertRegistroCatacion(objModel);

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
            RegistroCatacionDto objTemp = new RegistroCatacionDto();

            List<SelectListItem> listVariedad = new List<SelectListItem>();
            listVariedad = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.Variedad));
            ViewBag.Variedad = listVariedad;

            List<SelectListItem> listTipoLavado = new List<SelectListItem>();
            listTipoLavado = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoLavado));
            ViewBag.TipoLavado = listTipoLavado;

            var queryTable = await _registroCatacionService.GetRegistroCatacionById(id);

            objTemp = _mapper.Map<RegistroCatacionDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RegistroCatacionDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _registroCatacionService.GetRegistroCatacionById(id);
                RegistroCatacionDto Entity = _mapper.Map<RegistroCatacionDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _registroCatacionService.UpdateRegistroCatacion(objModel);
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
            RegistroCatacionDto objTemp = new RegistroCatacionDto();

            var queryTable = await _registroCatacionService.GetRegistroCatacionById(id);

            objTemp = _mapper.Map<RegistroCatacionDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _registroCatacionService.GetRegistroCatacionById(id);
                RegistroCatacionDto Entity = _mapper.Map<RegistroCatacionDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _registroCatacionService.DeleteRegistroCatacion(Entity);
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
