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
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IParametroGeneralService _parametroGeneralService;
        private readonly ICreateLogger _createLogger;
        private readonly IMapper _mapper;
        private readonly ICommonServices _commonServices;

        public ClientesController(IClienteService clienteService,
            ICreateLogger createLogger, IMapper mapper, ICommonServices commonServices,
            IParametroGeneralService parametroGeneralService)
        {
            _clienteService = clienteService;
            _createLogger = createLogger;
            _mapper = mapper;
            _commonServices = commonServices;
            _parametroGeneralService = parametroGeneralService;
        }

        public async Task<ActionResult> Index()
        {
            List<ClienteDto> lstTemp = new List<ClienteDto>();

            var queryTable = await _clienteService.GetAllClientes();

            lstTemp = _mapper.Map<List<ClienteDto>>(queryTable.Data);

            return View(lstTemp);
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClienteDto model = new ClienteDto();

            if (id.HasValue && id != 0)
            {
                var queryTable = await _clienteService.GetClienteById(id);

                model = _mapper.Map<ClienteDto>(queryTable.Data);
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

            CrearClienteDto model = new CrearClienteDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CrearClienteDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                objModel.CreateUser = User.Identity.Name;
                objModel.CreatedDate = DateTime.Now;

                vTemp = await _clienteService.InsertCliente(objModel);

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
            ClienteDto objTemp = new ClienteDto();

            List<SelectListItem> listTipoDocumento = new List<SelectListItem>();
            listTipoDocumento = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoDocumento));
            ViewBag.TipoDocumento = listTipoDocumento;

            List<SelectListItem> listTipoPersona = new List<SelectListItem>();
            listTipoPersona = await _parametroGeneralService.GetSelectListItems(Convert.ToInt32(Enumeracion.TipoCategoria.TipoPersona));
            ViewBag.TipoPersona = listTipoPersona;

            var queryTable = await _clienteService.GetClienteById(id);

            objTemp = _mapper.Map<ClienteDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClienteDto objModel)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _clienteService.GetClienteById(id);
                ClienteDto Entity = _mapper.Map<ClienteDto>(queryTable.Data);

                if (Entity != null)
                {
                    objModel.ModifiedUser = User.Identity.Name;
                    objModel.ModifiedDate = DateTime.Now;

                    vTemp = await _clienteService.UpdateCliente(objModel);
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
            ClienteDto objTemp = new ClienteDto();

            var queryTable = await _clienteService.GetClienteById(id);

            objTemp = _mapper.Map<ClienteDto>(queryTable.Data);

            return View(objTemp);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result vTemp = new Result();

            try
            {
                var queryTable = await _clienteService.GetClienteById(id);
                ClienteDto Entity = _mapper.Map<ClienteDto>(queryTable.Data);

                if (Entity != null)
                {
                    vTemp = await _clienteService.DeleteCliente(Entity);
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
