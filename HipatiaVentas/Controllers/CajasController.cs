using AutoMapper;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Commun.Utilidades;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Mvc;
using static HipatiaVentas.Commun.Enumeracion;

namespace HipatiaVentas.Controllers
{
    public class CajasController : Controller
    {
        private readonly ICajaService _cajaService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public CajasController(ICajaService cajaService,
            ICreateLogger createLogger, IMapper mapper, ICommonServices commonServices)
        {
            _cajaService = cajaService;
            _createLogger = createLogger;
            _mapper = mapper;
            _commonServices = commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<CajaDto> lstTemp = new List<CajaDto>();

            var queryTable = await _cajaService.GetAllCajas();

            lstTemp = _mapper.Map<List<CajaDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CajaDto model = new CajaDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _cajaService.GetCajaById(id);

                model = _mapper.Map<CajaDto>(queryTable.Data);
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            CrearCajaDto model = new CrearCajaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearCajaDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;

                vTemp = await _cajaService.InsertCaja(objModel);

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
            CajaDto objTemp = new CajaDto();

            var queryTable = await _cajaService.GetCajaById(id);

            objTemp = _mapper.Map<CajaDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CajaDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _cajaService.GetCajaById(id);
                CajaDto Entity = _mapper.Map<CajaDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _cajaService.UpdateCaja(objModel);
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
            CajaDto objTemp = new CajaDto();

            var queryTable = await _cajaService.GetCajaById(id);

            objTemp = _mapper.Map<CajaDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _cajaService.GetCajaById(id);
                CajaDto Entity = _mapper.Map<CajaDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _cajaService.DeleteCaja(Entity);
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
