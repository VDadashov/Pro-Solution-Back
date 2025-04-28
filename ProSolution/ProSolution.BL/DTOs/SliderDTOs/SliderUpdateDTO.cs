using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProSolution.BL.DTOs.SliderDTO;

namespace ProSolution.BL.DTOs.SliderDTOs
{
    public class SliderUpdateDTO
    {
        public IFormFile? ImagePath { get; set; }
        public string AltText { get; set; }
    }
    public class SliderUpdateDTOValidator : AbstractValidator<SliderUpdateDTO>
    {
        public SliderUpdateDTOValidator()
        {
            
            
            RuleFor(x => x.AltText)
                .NotEmpty()
                .WithMessage("Alt text cannot be empty.")
                .MaximumLength(5)
                .WithMessage("Alt text cannot exceed 250 characters.");
        }
    }
}
