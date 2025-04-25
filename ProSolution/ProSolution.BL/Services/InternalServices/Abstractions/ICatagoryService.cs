using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface ICatagoryService
    {
        Task<ICollection<Catagory>> GetAllAsync();
        Task<ICollection<Catagory>> GetAllDeletedAsync();
        Task<Catagory> RestoreAsync(int id);
        Task<Catagory> GetByIdAsync(int id);
        Task<Catagory> CreateAsync(CatagoryCreateDTO catagoryDto);
        Task<Catagory> UpdateAsync(int id, CatagoryDTO catagoryDto);
        Task<Catagory> SoftDeleteAsync(int id);
        Task<Catagory> HardDeleteAsync(int id);
    }
}
