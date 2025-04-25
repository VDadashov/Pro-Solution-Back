using ProSolution.BL.DTOs.BLogDTOs;
using ProSolution.BL.DTOs.PartnerDTO;
using ProSolution.BL.DTOs.PartnerDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IBlogService
    {
        Task<ICollection<Blog>> GetAllAsync();
        Task<ICollection<Blog>> GetAllDeletedAsync();
        Task<Blog> RestoreAsync(int id);
        Task<Blog> GetByIdAsync(int id);
        Task<Blog> CreateAsync(BlogCreateDTO blogCreateDTO);
        Task<Blog> UpdateAsync(int id, BlogUpdateDTO blogUpdateDTO);
        Task<Blog> SoftDeleteAsync(int id);
        Task<Blog> HardDeleteAsync(int id);
    }
}
