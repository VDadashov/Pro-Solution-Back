namespace ProSolution.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
