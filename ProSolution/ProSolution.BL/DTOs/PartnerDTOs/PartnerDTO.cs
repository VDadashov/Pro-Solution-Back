using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.PartnerDTO
{
    public record PartnerDTO
    {
        public IFormFile? ImagePath { get; set; }
        public string AltText { get; set; }
        public string? Title { get; set; }
        public string? Desctription { get; set; }
    }
}
