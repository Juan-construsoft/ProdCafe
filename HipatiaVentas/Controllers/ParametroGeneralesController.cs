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
    public class ParametroGeneralesController : Controller
    {        
        private readonly IParametroGeneralService _parametroGeneralService;
        private readonly ITipoCategoriaService _tipoCategoriaService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public ParametroGeneralesController(ICreateLogger createLogger, IMapper mapper, ICommonServices commonServices,
            IParametroGeneralService parametroGeneralService, ITipoCategoriaService tipoCategoriaService)
        {            
            _createLogger = createLogger;
            _mapper = mapper;
            _commonServices = commonServices;
            _parametroGeneralService = parametroGeneralService;
            _tipoCategoriaService = tipoCategoriaService;
        }

        public async Task<ActionResult> Index()
        {
            List<ParametroGeneralDto> lstTemp = new List<ParametroGeneralDto>();

            var queryTable = await _parametroGeneralService.GetAllParametroGenerales();

            lstTemp = _mapper.Map<List<ParametroGeneralDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ParametroGeneralDto model = new ParametroGeneralDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _parametroGeneralService.GetParametroGeneralById(id);

                model = _mapper.Map<ParametroGeneralDto>(queryTable.Data);
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            List<SelectListItem> listTipoCategoria = new List<SelectListItem>();
            listTipoCategoria = await _tipoCategoriaService.GetSelectListItems();
            ViewBag.TipoCategoria = listTipoCategoria;

            CrearParametroGeneralDto model = new CrearParametroGeneralDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearParametroGeneralDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;

                vTemp = await _parametroGeneralService.InsertParametroGeneral(objModel);

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
            ParametroGeneralDto objTemp = new ParametroGeneralDto();

            List<SelectListItem> listTipoCategoria = new List<SelectListItem>();
            listTipoCategoria = await _tipoCategoriaService.GetSelectListItems();
            ViewBag.TipoCategoria = listTipoCategoria;

            var queryTable = await _parametroGeneralService.GetParametroGeneralById(id);

            objTemp = _mapper.Map<ParametroGeneralDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ParametroGeneralDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _parametroGeneralService.GetParametroGeneralById(id);
                ParametroGeneralDto Entity = _mapper.Map<ParametroGeneralDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _parametroGeneralService.UpdateParametroGeneral(objModel);
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
            ParametroGeneralDto objTemp = new ParametroGeneralDto();

            var queryTable = await _parametroGeneralService.GetParametroGeneralById(id);

            objTemp = _mapper.Map<ParametroGeneralDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _parametroGeneralService.GetParametroGeneralById(id);
                ParametroGeneralDto Entity = _mapper.Map<ParametroGeneralDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _parametroGeneralService.DeleteParametroGeneral(Entity);
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
