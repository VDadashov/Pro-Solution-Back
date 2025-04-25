using ProSolution.BL.DTOs;
using ProSolution.BL.DTOs.SliderDTO;
using ProSolution.Core.Entities;
using ProSolution.Core.Enums;

namespace ProSolution.BL.Services.InternalServices.Abstractions
{
    public interface ISliderService
    {
        Task<ICollection<Slider>> GetAllAsync();
        Task<ICollection<Slider>> GetAllDeletedAsync();
        Task<Slider> RestoreAsync(int id);
        Task<Slider> GetByIdAsync(int id);
        Task<Slider> CreateAsync(SliderCreateDTO sliderCreateDTO);
        Task<Slider> UpdateAsync(int id, SliderCreateDTO sliderCreateDTO);
        Task<Slider> SoftDeleteAsync(int id);
        Task<Slider> HardDeleteAsync(int id);
        Task<PagedResult<Slider>> GetPaginatedAsync(PaginationParams @params);

    }
}
