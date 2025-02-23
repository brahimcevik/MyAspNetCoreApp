﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspNetCoreApp.Wep.Helpers;
using MyAspNetCoreApp.Wep.Models;

using MyAspNetCoreApp.Wep.ViewModels;
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
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, AppDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var products = _context.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
            }).ToList();

            ViewBag.productListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        public IActionResult Privacy()
        {
            var products = _context.Products.OrderByDescending(x => x.Id).Select(x => new ProductPartialViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
            }).ToList();

            ViewBag.productListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult Visitor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {
            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);

                visitor.Created= DateTime.Now;  


                _context.Visitors.Add(visitor);
                _context.SaveChanges();
                TempData["result"] = "Yorum Kaydedilmiştir";
                return RedirectToAction(nameof(HomeController.Visitor));
            }
            catch (Exception)
            {
                TempData["result"] = "Yorum Kaydedilirken Hata Meydana Geldi ";
                return RedirectToAction(nameof(HomeController.Visitor));
               
            }




          
        }

    }
}
