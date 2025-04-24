using ProSolution.Core.Entities.Commons;

namespace ProSolution.Core.Entities.Commons
{
    public abstract class BaseEntity : BaseAuditableEntity
    { 
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
