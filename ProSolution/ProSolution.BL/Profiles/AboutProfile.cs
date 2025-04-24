using AutoMapper;
using ProSolution.BL.DTOs.AboutDTOs;
using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Profiles
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<About, AboutDetailDTO>();
            CreateMap<AboutUpdateDTO, About>();
        }
    }
}
