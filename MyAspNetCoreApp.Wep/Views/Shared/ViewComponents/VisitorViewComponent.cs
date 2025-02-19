using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Wep.Models;
using MyAspNetCoreApp.Wep.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Wep.Views.Shared.ViewComponents
{
    public class VisitorViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public VisitorViewComponent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            var visitors = _context.Visitors.ToList();

            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitors);
            ViewBag.visitorViewModels= visitorViewModels;
            return View();
        }
    }
}
