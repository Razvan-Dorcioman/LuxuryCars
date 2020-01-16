using LuxuryCars.Models.Entities;
using LuxuryCars.ViewModels;
using AutoMapper;

namespace LuxuryCars.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().
                ReverseMap();
        }
    }
}