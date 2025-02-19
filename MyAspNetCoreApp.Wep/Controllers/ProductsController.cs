using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyAspNetCoreApp.Wep.Helpers;
using MyAspNetCoreApp.Wep.Models;
using MyAspNetCoreApp.Wep.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAspNetCoreApp.Wep.Controllers
{
    public class ProductsController : Controller
    {

        private AppDbContext _context;




        private readonly IMapper _mapper;



        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context, IHelper helper, IMapper mapper)
        {
            //DI Container
            //Dependency Injection Pattern

            _productRepository = new ProductRepository();





            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {


            var products = _context.Products.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }



        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Add()
        {


            ViewBag.Expire = new Dictionary<string, int>()
             {
                 {"1 Ay",1 },
                 {"3 Ay",3 },
                 {"6 Ay",6 },
                 {"12 Ay",12 }
             };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new() {Data="Mavi",Value="Mavi" },
                new() {Data="Sarı",Value="Sarı" },
                new() {Data="Yeşi",Value="Yeşil" }

                }, "Value", "Data");


            return View();
        }


        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            //if (!string.IsNullOrEmpty(newProduct.Name) && newProduct.Name.StartsWith("A"))
            //{

            //    ModelState.AddModelError(string.Empty, "Ürün ismi A harfi İle Başlayamaz");
            //}





            ViewBag.Expire = new Dictionary<string, int>()
             {
                 {"1 Ay",1 },
                 {"3 Ay",3 },
                 {"6 Ay",6 },
                 {"12 Ay",12 }
             };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new() {Data="Mavi",Value="Mavi" },
                new() {Data="Sarı",Value="Sarı" },
                new() {Data="Yeşi",Value="Yeşil" }

                }, "Value", "Data");


            if (ModelState.IsValid)
            {

                try
                {

                    _context.Products.Add(_mapper.Map<Product>(newProduct));

                    _context.SaveChanges();
                    TempData["status"] = "Ürün Başarıyla Eklandi!";

                    return RedirectToAction("Index");
                }
                catch (System.Exception)
                {
                    ModelState.AddModelError(string.Empty, "Ürün Kaydedilirken Bir Hata Meydana geldi.");
                    return View();

                }






            }
            else
            {

                return View();
            }
            //Request Header-Body

            ////1 yöntem

            //var name=HttpContext.Request.Form["Name"].ToString();
            //var price=decimal.Parse( HttpContext.Request.Form["Price"]);
            //var stock=int.Parse( HttpContext.Request.Form["Stock"]);
            //var color = HttpContext.Request.Form["Color"].ToString();



            //2. Yöntem
            //Product newProduct = new Product()
            //{ Name = Name, Price = Price, Color = Color, Stock = Stock };


        }





        //[HttpGet]
        //public IActionResult SaveProduct(Product newProduct)
        //{


        //    //Request Header-Body

        //    ////1 yöntem

        //    //var name=HttpContext.Request.Form["Name"].ToString();
        //    //var price=decimal.Parse( HttpContext.Request.Form["Price"]);
        //    //var stock=int.Parse( HttpContext.Request.Form["Stock"]);
        //    //var color = HttpContext.Request.Form["Color"].ToString();



        //    //2. Yöntem
        //    //Product newProduct = new Product()
        //    //{ Name = Name, Price = Price, Color = Color, Stock = Stock };

        //    _context.Products.Add(newProduct);

        //    _context.SaveChanges();

        //    return View();  
        //}




        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;
            ViewBag.Expire = new Dictionary<string, int>()
             {
                 {"1 Ay",1 },
                 {"3 Ay",3 },
                 {"6 Ay",6 },
                 {"12 Ay",12 }
             };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new() {Data="Mavi",Value="Mavi" },
                new() {Data="Sarı",Value="Sarı" },
                new() {Data="Yeşi",Value="Yeşil" }

                }, "Value", "Data", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {

            

                ViewBag.ExpireValue = updateProduct.Expire;
                ViewBag.Expire = new Dictionary<string, int>()
             {
                 {"1 Ay",1 },
                 {"3 Ay",3 },
                 {"6 Ay",6 },
                 {"12 Ay",12 }
             };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {


                new() {Data="Mavi",Value="Mavi" },
                new() {Data="Sarı",Value="Sarı" },
                new() {Data="Yeşi",Value="Yeşil" }

                }, "Value", "Data", updateProduct.Color);


                return View();
            }



            _context.Products.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
            TempData["status"] = "Ürün Başarıyla Güncellendi!";
            return RedirectToAction("Index");
        }



        [AcceptVerbs("GET","POST")]
        public ActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());

            if (anyProduct)
            {
                return Json("Kaydetmeye çalıştığınız isim Alınmış");
            }
            else
            {
                return Json(true);
            }
        }



    }
}
