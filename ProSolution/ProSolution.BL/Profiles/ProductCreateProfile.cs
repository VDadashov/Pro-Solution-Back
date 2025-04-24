using AutoMapper;
using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ProductDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class ProductCreateProfile : Profile
    {
        public ProductCreateProfile()
        {
            CreateMap<ProductCreateDTO, Product>()
           .ForMember(dest => dest.CatagoryId, opt => opt.MapFrom(src => src.CategoryId));
            CreateMap<ProductUpdateDTO, Product>()
            .ForMember(dest => dest.CatagoryId, opt => opt.MapFrom(src => src.CategoryId));

            CreateMap<Product, ProductReadDTO>()
               .ForMember(dest => dest.Catagory, opt => opt.MapFrom(src => new CatagoryDTO
               {
                   Id = src.Catagory.Id,
                   Title = src.Catagory.Title
               })).ReverseMap();
        }
    }
}
