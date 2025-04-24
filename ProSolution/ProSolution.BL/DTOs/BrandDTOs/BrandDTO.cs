using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.BrandDTO
{
    public record BrandDTO
    {
        public IFormFile ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
