using AutoMapper;
using ProductShowcase.Entities;
using ProductShowcase.ServiceModels;

namespace ProductShowcase.Profiles
{
    public class SmartphoneProfile : Profile
    {
        public SmartphoneProfile() {
            CreateMap<ProductDto, Smartphone>()
                .ForMember(dest => dest.SizeScreen, opt => opt.MapFrom(input => input.SmartphoneDetails.SizeScreen));
        }
    }
}
