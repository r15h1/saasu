using Microsoft.AspNetCore.Mvc;
using Saasu.Core;

namespace Saasu.Web.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {                
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("themes")]
        public IActionResult Themes()
        {
            return View();
        }
    }
}
