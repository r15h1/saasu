using Microsoft.AspNetCore.Mvc;
using Saasu.Core;

namespace Saasu.Web.Controllers
{
     public class HomeController : Controller
    {
        private Tenant tenant;

        public HomeController(Tenant tenant)
        {
            this.tenant = tenant;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Themes()
        {
            return View();
        }
    }
}
