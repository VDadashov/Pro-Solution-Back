using ProSolution.BL.DTOs.BadgeDTOs;
using ProSolution.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IBadgeService
    {
        Task<ICollection<BadgeListItemDTO>> GetAllAsync();
        Task<ICollection<BadgeListItemDTO>> GetAllDeletedAsync();
        Task<Badge> RestoreAsync(int id);
        Task<Badge> CreateAsync(BadgeCreateDTO createDTO);
        Task<Badge> UpdateAsync(int id, BadgeUpdateDTO updateDTO);
        Task<Badge> SoftDeleteAsync(int id);
        Task<Badge> HardDeleteAsync(int id);
    }
}
