using AutoMapper;
using MyAspNetCoreApp.Wep.Models;
using MyAspNetCoreApp.Wep.ViewModels;

namespace MyAspNetCoreApp.Wep.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<Visitor,VisitorViewModel>().ReverseMap();
        }
    }
}
