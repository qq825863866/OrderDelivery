using Microsoft.AspNetCore.Mvc;

namespace Ods.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
