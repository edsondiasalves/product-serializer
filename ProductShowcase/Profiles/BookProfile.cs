using AutoMapper;
using ProductShowcase.Entities;
using ProductShowcase.ServiceModels;

namespace ProductShowcase.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<ProductDto, Book>()
                .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(input => input.BookDetails.TotalPages));
        }
    }
}
