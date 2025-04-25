using AutoMapper;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Core.Entities;

namespace ProSolution.Business.MappingProfiles
{
    public class SEOMP : Profile
    {
        public SEOMP()
        {
            //Create
            CreateMap<CreateSEODTO, SeoData>().ReverseMap();

            //Update
            CreateMap<UpdateSEODTO, SeoData>().ReverseMap();
        }
    }
}
