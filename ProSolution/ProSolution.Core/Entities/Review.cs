using ProSolution.Core.Entities.Commons;
using ProSolution.Core.Enums;

namespace ProSolution.Core.Entities
{
    public class Review : BaseEntity
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool SaveMe { get; set; }
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
        public RaitingEnum Raiting { get; set; }

    }
}
