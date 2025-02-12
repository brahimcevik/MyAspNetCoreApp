using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Wep.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoLayout()
        {
            return View();

        }
    }
}
