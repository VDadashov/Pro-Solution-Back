using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IPartnerService
    {
        Task<ICollection<Partner>> GetAllAsync();
        Task<ICollection<Partner>> GetAllDeletedAsync();
        Task<Partner> RestoreAsync(int id);
        Task<Partner> GetByIdAsync(int id);
        Task<Partner> CreateAsync(PartnerDTO partnerDTO);
        Task<Partner> UpdateAsync(int id, PartnerDTO partnerDTO);
        Task<Partner> SoftDeleteAsync(int id);
        Task<Partner> HardDeleteAsync(int id);
    }
}
