using AutoMapper;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.BL.DTOs.SliderDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider , SliderCreateDTO>().ReverseMap();
            CreateMap<Slider , SliderUpdateDTO>().ReverseMap();
        }
    }
}
