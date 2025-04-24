using AutoMapper;
using ProSolution.BL.DTOs.ReviewDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewDTO, Review>().ReverseMap();
        }
    }
}
