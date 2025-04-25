using AutoMapper;
using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class CatagoryProfile : Profile
    {
        public CatagoryProfile()
        {
            CreateMap<Catagory, CatagoryDTO>().ReverseMap();
            CreateMap<Catagory, CatagoryCreateDTO>().ReverseMap();
        }
    }
}
