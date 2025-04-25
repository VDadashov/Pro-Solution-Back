using ProSolution.BL.DTOs.BrandDTO;
using ProSolution.BL.DTOs.BrandDTOs;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IBrandService
    {
        Task<ICollection<Brand>> GetAllAsync();
        Task<ICollection<Brand>> GetAllDeletedAsync();
        Task<Brand> RestoreAsync(int id);
        Task<Brand> GetByIdAsync(int id);
        Task<Brand> CreateAsync(BrandCreateDTO brandDTO);
        Task<Brand> UpdateAsync(int id, BrandDTO brandDTO);
        Task<Brand> SoftDeleteAsync(int id);
        Task<Brand> HardDeleteAsync(int id);
    }
}
