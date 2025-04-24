using AutoMapper;
using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Profiles
{
    public class BadgeProfile : Profile
    {
        public BadgeProfile()
        {
            CreateMap<Badge, BadgeListItemDTO>();
            CreateMap<BadgeUpdateDTO, Badge>();
            CreateMap<BadgeCreateDTO, Badge>();

        }
    }
    
    
}
