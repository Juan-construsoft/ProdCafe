using AutoMapper;
using HipatiaVentas.Commun.Logs;
using HipatiaVentas.Domain.Dtos;
using HipatiaVentas.Models;
using HipatiaVentas.Services.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HipatiaVentas.Controllers
{
    public class LoginController : Controller
    {
        private readonly ICreateLogger _createLogger;
        private readonly IBackOfficeService objService;
        private readonly IMapper mapper;

        public LoginController(IBackOfficeService _objService, IMapper _mapper)
        {
            this.objService = _objService;
            this.mapper = _mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            LoginModel loginModel = new LoginModel();

            try
            {
                loginModel.Email = username;
                loginModel.Password = password;

                var vRespuesta = await objService.ValidarLogin(loginModel);

                if (vRespuesta.Success == true)
                {
                    var objTemp = mapper.Map<UsuarioLoginDto>(vRespuesta.Data);

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, objTemp.UserName ),
                        new Claim(ClaimTypes.NameIdentifier,  objTemp.Id),
                        new Claim(ClaimTypes.Role,objTemp.Rol)
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    AuthenticationProperties properties = new AuthenticationProperties()
                    {
                        AllowRefresh = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                }
                else
                {

                    ViewData["Mensaje"] = "No se encontraron coincidencias";
                    return View();
                }
            }
            catch (Exception ex)
            {
                _createLogger.LogWriteExcepcion(ex.Message);
                ViewData["Mensaje"] = ex.Message;

                return BadRequest();
            }

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
