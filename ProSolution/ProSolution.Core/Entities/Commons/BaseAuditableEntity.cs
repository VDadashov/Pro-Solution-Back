namespace ProSolution.Core.Entities.Commons
{
    public abstract class BaseAuditableEntity
    {
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
