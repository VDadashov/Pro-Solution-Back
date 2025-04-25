using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.PartnerDTO
{
    public record PartnerDTO
    {
        public IFormFile? ImagePath { get; set; }
    }
}
