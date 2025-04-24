using ProSolution.BL.DTOs.AboutDTOs;
using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IAboutService
    {
        Task<AboutDetailDTO> GetAsync();

        Task<About> UpdateAsync(AboutUpdateDTO updateDTO);
    }
}
