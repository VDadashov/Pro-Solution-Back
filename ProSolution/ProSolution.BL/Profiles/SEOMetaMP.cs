using AutoMapper;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Core.Entities;

namespace ProSolution.Business.MappingProfiles
{
    public class SEOMetaMP : Profile
    {
        public SEOMetaMP()
        {
            //Create
            CreateMap<CreateSEOMetaDTO, SeoMeta>().ReverseMap();

            //Update
            CreateMap<UpdateSEOMetaDTO, SeoMeta>().ReverseMap();
        }
    }
}
