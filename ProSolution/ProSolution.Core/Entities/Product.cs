using ProSolution.Core.Entities.Commons;

namespace ProSolution.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public int CatagoryId {  get; set; }
        public int Stock { get; set; }
        public int SoldCount { get; set; } = 0;
        public float? Dicount { get; set; } 
        public DateTime? DiscountEndDate { get; set; }
        public Catagory Catagory { get; set; }
    }
}
