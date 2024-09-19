using HipatiaVentas.Commun;
using Microsoft.AspNetCore.Mvc;

namespace HipatiaVentas.Controllers
{
    public class DashboardController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return Redirect(Constantes.routeLogin);
            }

            //return View();
        }

        [ActionName("Analytics")]
        public IActionResult Analytics()
        {
            return View();
        }

        [ActionName("CRM")]
        public IActionResult CRM()
        {
            return View();
        }

        [ActionName("Crypto")]
        public IActionResult Crypto()
        {
            return View();
        }

        [ActionName("Projects")]
        public IActionResult Projects()
        {
            return View();
        }

        [ActionName("NFT")]
        public IActionResult NFT()
        {
            return View();
        }

        [ActionName("Job")]
        public IActionResult Job()
        {
            return View();
        }
    }
}
