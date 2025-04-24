using ProSolution.Core.Entities.Commons;

namespace ProSolution.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImagePath { get; set; } 
        public string AltText { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public bool IsMain { get; set; }
    }
}
