using ProSolution.Core.Entities.Commons;

namespace ProSolution.Core.Entities;

public class Catagory : BaseEntity
{
    public string Title { get; set; }
    public int? ParentCatagoryId { get; set; }
    public ICollection<Product> Products { get; set; }
}