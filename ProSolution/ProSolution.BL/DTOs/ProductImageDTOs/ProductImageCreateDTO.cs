using FluentValidation;
using Microsoft.AspNetCore.Http;
using ProSolution.BL.DTOs.SliderDTO;

namespace ProSolution.BL.DTOs.ProductImageDTOs
{
    public class ProductImageCreateDTO
    {
        public IFormFile File { get; set; }
        public bool IsMain { get; set; }
        public string? AltText { get; set; }
    }

    public class ProductImageCreateDTOValidator : AbstractValidator<ProductImageCreateDTO>
    {
        public ProductImageCreateDTOValidator()
        {
            RuleFor(x => x.File)
                .NotNull()
                .WithMessage("Image path cannot be null.");
           
            RuleFor(x => x.AltText)
                .NotEmpty()
                .WithMessage("Alt text cannot be empty.")
                .MaximumLength(250)
                .WithMessage("Alt text cannot exceed 250 characters.");
        }
    }

}
