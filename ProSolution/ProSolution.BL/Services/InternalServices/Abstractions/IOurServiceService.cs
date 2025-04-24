using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.ServiceDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IOurServiceService
    {
        Task<ICollection<OurServiceListItemDTO>> GetAllAsync();
        Task<ICollection<OurServiceListItemDTO>> GetAllDeletedAsync();
        Task<OurService> RestoreAsync(int id);
        Task<OurServiceDetailDTO> GetByIdAsync(int id);
        Task<OurService> CreateAsync(OurServiceCreateDTO createDTO);
        Task<OurService> UpdateAsync(int id, OurServiceUpdateDTO updateDTO);
        Task<OurService> SoftDeleteAsync(int id);
        Task<OurService> HardDeleteAsync(int id);
        Task<ICollection<OurServiceListItemDTO>> SearchServicestsAsync(string search);
    }
    
}
