using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ReviewDTOs;
using ProSolution.Core.Entities;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetAllAsync();
        Task<ICollection<Review>> GetAllDeletedAsync();
        Task<Review> RestoreAsync(int id);
        Task<Review> GetByIdAsync(int id);
        Task<Review> CreateAsync(ReviewDTO reviewDTO);
        Task<Review> UpdateAsync(int id, ReviewDTO reviewDTO);
        Task<Review> SoftDeleteAsync(int id);
        Task<Review> HardDeleteAsync(int id);
    }
}
