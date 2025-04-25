using AutoMapper;
using ProSolution.BL.DTOs.BrandDTO;
using ProSolution.BL.DTOs.BrandDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Brand, BrandCreateDTO>().ReverseMap();
        }
    }
}
