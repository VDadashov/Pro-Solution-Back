using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.SliderDTOs
{
    public class SliderUpdateDTO
    {
        public IFormFile? ImagePath { get; set; }
        public string AltText { get; set; }
    }
}
