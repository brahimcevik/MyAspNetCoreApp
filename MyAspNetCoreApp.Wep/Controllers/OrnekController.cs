using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyAspNetCoreApp.Wep.Controllers
{ 
     public class Product2
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
   
    public class OrnekController : Controller
    {


       

        public IActionResult Index()
        {

            var productList = new List<Product2>()
            {
                new(){Id = 1,Name="ibrahim"},
                new(){Id = 2,Name="Ahmet"},
                new(){Id = 3,Name="Veli"}
            };
            
            return View(productList);


            //    ViewBag.name = "Asp.Net Core";
            //TempData["surname"]= "Sayfalar Arası Data Taşıma";
            //ViewData["age"] = 30;
            //ViewData["names"]=new List<string>() {"ahmet","mehmet","hasan"};
            //ViewBag.person = new { Id = 1, Name = "ahmet", Age = 23 };

        }
        public IActionResult Index2()
        {
            var surname = TempData["surname"];
            return View();
        }
        public IActionResult Index3()
        {
            //return View();
            return RedirectToAction("Index", "Ornek");
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });
        }
        public IActionResult JsonResultParametre(int id)
        {

            return Json(new { Id = id,name ="ibrahim" });
        }
        public IActionResult ContentResult()
        {
            return Content("ContentResult");

        }
        public IActionResult JsonResult()
        {

            return Json(new { Id = 1, name = "kalem", price = 100 });
        }
        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
