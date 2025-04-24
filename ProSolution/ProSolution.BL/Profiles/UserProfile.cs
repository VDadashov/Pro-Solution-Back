using AutoMapper;
using ProSolution.BL.DTOs.AuthDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User,RegisterDTO>().ReverseMap();
        }
    }
}
