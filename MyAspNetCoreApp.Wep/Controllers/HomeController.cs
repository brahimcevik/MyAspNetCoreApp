using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspNetCoreApp.Wep.Helpers;
using MyAspNetCoreApp.Wep.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Wep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHelper _helper;

        public HomeController(ILogger<HomeController> logger,IHelper helper)
        {
            _logger = logger;
            _helper = helper;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var text = "as-.net";
            var upperText=_helper.Upper(text);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
