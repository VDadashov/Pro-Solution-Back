using AutoMapper;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<Slider , SliderCreateDTO>().ReverseMap();
        }
    }
}
