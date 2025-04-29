using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.DTOs.PartnerDTOs;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IPartnerService
    {
        Task<ICollection<Partner>> GetAllAsync();
        Task<ICollection<Partner>> GetAllDeletedAsync();
        Task<Partner> RestoreAsync(int id);
        Task<Partner> GetByIdAsync(int id);
        Task<Partner> CreateAsync(PartnerCreateDTO partnerDTO);
        Task<Partner> UpdateAsync(int id, PartnerDTO partnerDTO);
        Task<Partner> SoftDeleteAsync(int id);
        Task<Partner> HardDeleteAsync(int id);
        Task<PagedResult<Partner>> GetPaginatedAsync(PaginationParams @params);

    }
}
