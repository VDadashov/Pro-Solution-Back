using AutoMapper;
using ProSolution.Business.DTOs.SEOUrlDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.Business.MappingProfiles
{
    public class SEOUrlMP : Profile
    {
        public SEOUrlMP()
        {
            //Create
            CreateMap<CreateSEOUrlDTO, SeoUrl>().ReverseMap();

            //Update
            CreateMap<UpdateSEOUrlDTO, SeoUrl>().ReverseMap();
        }
    }
}
