using Microsoft.AspNetCore.Http;
using ProSolution.Core.Entities;

namespace ProSolution.BL.DTOs.BLogDTOs
{
    public class BlogCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImagePath { get; set; }
        public string UserId { get; set; }
    }
}
