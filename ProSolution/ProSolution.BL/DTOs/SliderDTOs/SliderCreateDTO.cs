using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ProSolution.BL.DTOs.SliderDTO
{
    public class SliderCreateDTO
    {
        public IFormFile ImagePath { get; set; }
        public string AltText { get; set; }

    }
    public class SliderCreateDTOValidator : AbstractValidator<SliderCreateDTO>
    {
        public SliderCreateDTOValidator()
        {
            RuleFor(x => x.ImagePath)
                .NotNull()
                .WithMessage("Image path cannot be null.");
                //.Must(x => x.ContentType == "image/jpeg" || x.ContentType == "image/png")
                //.WithMessage("Image must be in JPEG or PNG format.");
            RuleFor(x => x.AltText)
                .NotEmpty()
                .WithMessage("Alt text cannot be empty.")
                .MaximumLength(250)
                .WithMessage("Alt text cannot exceed 250 characters.");
        }
    }
}
