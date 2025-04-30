using ProSolution.BL.DTOs.CatagoryDTOs;
using ProSolution.BL.DTOs.ProductImageDTOs;

namespace ProSolution.BL.DTOs.ProductDTOs
{
    public class ProductReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? NewPrice { get; set; }
        public DateTime? DiscountEndDate { get; set; }
        //public List<ProductImageCreateDTO> Images { get; set; }
        public List<ProductImageDTO> ProductImages { get; set; }
        //public ProductImageCreateDTO ProductImageCreateDTO { get; set; }
        //public string ImagePath { get; set; }
        public CatagoryDTO Catagory { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int Stock { get; set; }
        public int SoldCount { get; set; } 
        public float? Dicount { get; set; }
    }
}
