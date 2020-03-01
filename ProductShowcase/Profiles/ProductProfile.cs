using AutoMapper;
using ProductShowcase.Entities;
using ProductShowcase.ServiceModels;

namespace ProductShowcase.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<ProductDto, Product>();
        }
    }
}
