using AutoMapper;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Profiles
{
    public class PartnerProfile : Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDTO>().ReverseMap();
        }
    }
}
