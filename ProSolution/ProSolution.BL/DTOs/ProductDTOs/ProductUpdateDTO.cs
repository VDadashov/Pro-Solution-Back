using Microsoft.AspNetCore.Http;
using ProSolution.BL.DTOs.ProductImageDTOs;

namespace ProSolution.BL.DTOs.ProductDTOs
{
    public class ProductUpdateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        //public IFormFile? ImagePath { get; set; }
        public List<ProductImageCreateDTO>? Images { get; set; }

        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public int SoldCount { get; set; } 
        public float? Dicount { get; set; }
        public DateTime? DiscountEndDate { get; set; }

    }
}
