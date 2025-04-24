using AutoMapper;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Profiles
{
    public  class OurServiceMappingProfile :Profile
    {
        public OurServiceMappingProfile()
        { 
            CreateMap<OurService, OurServiceDetailDTO>();
            CreateMap<OurService, OurServiceListItemDTO>();
            CreateMap<OurServiceUpdateDTO,OurService>();
            CreateMap<OurServiceCreateDTO,OurService>();

        }

    }
}
