using AutoMapper;
using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ProductDTOs;
using ProSolution.BL.DTOs.ProductImageDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class ProductCreateProfile : Profile
    {
        public ProductCreateProfile()
        {

            CreateMap<ProductImage, ProductImageDTO>();
            CreateMap<Product, ProductReadDTO>()
                .ForMember(dest => dest.Catagory, opt => opt.MapFrom(src => new CatagoryDTO
                {
                    Id = src.Catagory.Id,
                    Title = src.Catagory.Title
                }))
                .ForMember(dest => dest.ProductImages, opt => opt.MapFrom(src => src.ProductImages));

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
