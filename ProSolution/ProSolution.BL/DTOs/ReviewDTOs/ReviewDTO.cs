using ProSolution.Core.Enums;

namespace ProSolution.BL.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        public string Message { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool SaveMe { get; set; }
        public int BlogId { get; set; }
        public RaitingEnum Raiting { get; set; }
    }
}
