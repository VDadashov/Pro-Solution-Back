using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.BLogDTOs
{
    public class BlogReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
