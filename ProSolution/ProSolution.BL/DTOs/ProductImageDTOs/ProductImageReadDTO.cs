using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.ProductImageDTOs
{
    public class ProductImageReadDTO
    {
        public string File { get; set; }
        public bool IsMain { get; set; }
        public string? AltText { get; set; }
    }
}
