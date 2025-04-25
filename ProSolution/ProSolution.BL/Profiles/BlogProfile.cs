using AutoMapper;
using ProSolution.BL.DTOs.BLogDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<Blog , BlogCreateDTO>().ReverseMap();
            CreateMap<Blog , BlogUpdateDTO>().ReverseMap();
        }
    }
}
