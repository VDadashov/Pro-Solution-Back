using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ReviewDTOs;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IReviewService
    {
        Task<ICollection<Review>> GetAllAsync();
        Task<ICollection<Review>> GetAllDeletedAsync();
        Task<ICollection<ReviewDTO>> GetReviewsByBlogIdAsync(int blogId);
        Task<Review> RestoreAsync(int id);
        Task<Review> GetByIdAsync(int id);
        Task<Review> CreateAsync(ReviewDTO reviewDTO);
        Task<Review> UpdateAsync(int id, ReviewDTO reviewDTO);
        Task<Review> SoftDeleteAsync(int id);
        Task<Review> HardDeleteAsync(int id);
        Task<PagedResult<Review>> GetPaginatedAsync(PaginationParams @params);

    }
}
