using ProSolution.BL.DTOs.ProductDTOs;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface IProductService 
    {
        Task<ICollection<ProductReadDTO>> GetAllAsync();
        Task<ICollection<ProductReadDTO>> GetFilteredPrice(int minPirce , int maxPrice);
        Task<ICollection<ProductReadDTO>> GetAllDiscountProductAsync();
        Task<ICollection<ProductReadDTO>> GetMostSoldProductAsync();
        Task<ICollection<ProductReadDTO>> GetNewestDiscountedProductsAsync();
        Task<ICollection<ProductReadDTO>> GetNewestProductsAsync();
        Task<ICollection<ProductReadDTO>> SearchProductsAsync(string search);
        Task<ICollection<ProductReadDTO>> GetAllDeletedAsync();
        Task<Product> CreateAsync(ProductCreateDTO productCreateDTO);
        Task<Product> UpdateAsync(int id , ProductUpdateDTO productUpdateDTO);
        Task<ProductReadDTO> GetByIdAsync(int id);
        Task<Product> SoftDeleteAsync(int id);
        Task<Product> HardDeleteAsync(int id);
        Task<Product> RestoreAsync(int id);
        Task<PagedResult<ProductReadDTO>> GetPaginatedAsync(PaginationParams @params);

    }
}
