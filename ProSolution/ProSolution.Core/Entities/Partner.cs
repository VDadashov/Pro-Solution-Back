using ProSolution.Core.Entities.Commons;

namespace ProSolution.Core.Entities;

public class Partner: BaseEntity
{
    public string ImagePath { get; set; }
    public string AltText { get; set; }
    public string? Title { get; set; }
    public string? Desctription { get; set; }

}
