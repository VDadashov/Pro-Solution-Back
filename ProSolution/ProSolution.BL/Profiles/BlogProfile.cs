using AutoMapper;
using ProSolution.BL.DTOs.BLogDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<Blog, BlogCreateDTO>().ReverseMap();
        CreateMap<Blog, BlogUpdateDTO>().ReverseMap();
        CreateMap<Blog, BlogReadDTO>()
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName))
    .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt))
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
    .ReverseMap();
    }
}
