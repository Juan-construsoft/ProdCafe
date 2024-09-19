using AutoMapper;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Commun.Utilidades;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using HipatiaVentas.Services.Service;
using Microsoft.AspNetCore.Mvc;
using static HipatiaVentas.Commun.Enumeracion;

namespace HipatiaVentas.Controllers
{
    public class TipoCategoriasController : Controller
    {
        private readonly ITipoCategoriaService _tipoCategoriaService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public TipoCategoriasController(ITipoCategoriaService tipoCategoriaService,
            ICreateLogger createLogger, IMapper mapper, ICommonServices commonServices)
        {
            _tipoCategoriaService = tipoCategoriaService;
            _createLogger = createLogger;
            _mapper = mapper;
            _commonServices = commonServices;
        }

        public async Task<ActionResult> Index()
        {
            List<TipoCategoriaDto> lstTemp = new List<TipoCategoriaDto>();

            var queryTable = await _tipoCategoriaService.GetAllTipoCategorias();

            lstTemp = _mapper.Map<List<TipoCategoriaDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoCategoriaDto model = new TipoCategoriaDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _tipoCategoriaService.GetTipoCategoriaById(id);

                model = _mapper.Map<TipoCategoriaDto>(queryTable.Data);
            }

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            CrearTipoCategoriaDto model = new CrearTipoCategoriaDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearTipoCategoriaDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;

                vTemp = await _tipoCategoriaService.InsertTipoCategoria(objModel);

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
            TipoCategoriaDto objTemp = new TipoCategoriaDto();

            var queryTable = await _tipoCategoriaService.GetTipoCategoriaById(id);

            objTemp = _mapper.Map<TipoCategoriaDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoCategoriaDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _tipoCategoriaService.GetTipoCategoriaById(id);
                TipoCategoriaDto Entity = _mapper.Map<TipoCategoriaDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _tipoCategoriaService.UpdateTipoCategoria(objModel);
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
            TipoCategoriaDto objTemp = new TipoCategoriaDto();

            var queryTable = await _tipoCategoriaService.GetTipoCategoriaById(id);

            objTemp = _mapper.Map<TipoCategoriaDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _tipoCategoriaService.GetTipoCategoriaById(id);
                TipoCategoriaDto Entity = _mapper.Map<TipoCategoriaDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _tipoCategoriaService.DeleteTipoCategoria(Entity);
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
