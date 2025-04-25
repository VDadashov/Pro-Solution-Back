using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.BrandDTOs
{
    public class BrandCreateDTO
    {
        public IFormFile ImagePath { get; set; }
        public string AltText { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
