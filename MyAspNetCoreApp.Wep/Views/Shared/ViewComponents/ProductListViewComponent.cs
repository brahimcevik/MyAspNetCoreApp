﻿using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Wep.Models;
using MyAspNetCoreApp.Wep.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Wep.Views.Shared.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductListViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int type=1)
        {
            var viewmodels = _context.Products.Select(x => new ProductListComponentViewModel()
            {
                Name = x.Name,
                Description = x.Description,
            }).ToList();

            if (type == 1)
            {
                return View("Default",viewmodels);
            }
            else
            {
                return View("Type2",viewmodels);
            }
           
        }

    }
}
