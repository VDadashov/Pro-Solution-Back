using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.PartnerDTOs
{
    public class PartnerCreateDTO
    {
        public IFormFile ImagePath { get; set; }
        public string AltText { get; set; }
        public string? Title { get; set; }
        public string? Desctription { get; set; }
    }
}
