using FluentValidation;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Business.DTOs.SEOUrlDTOs;

namespace ProSolution.Business.Validators.SEOValidator
{
    public class UpdateSEODTOValidator : AbstractValidator<UpdateSEODTO>
    {
        public UpdateSEODTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(dto => dto.AltText)
                .NotEmpty().WithMessage("AltText is required.")
                .MaximumLength(360).WithMessage("AltText must be 360 characters or less.");

            RuleFor(dto => dto.AnchorText)
                .NotEmpty().WithMessage("AnchorText is required.")
                .MaximumLength(1600).WithMessage("AnchorText must be 160 characters or less.");
        }
    }

    public class UpdateSEOMetaDTOValidator : AbstractValidator<UpdateSEOMetaDTO>
    {
        public UpdateSEOMetaDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(dto => dto.MetaDescription)
                .MaximumLength(360).WithMessage("Meta Description must be 360 characters or less.");

            RuleFor(dto => dto.MetaTitle)
                .MaximumLength(1600).WithMessage("Meta Title must be 160 characters or less.");

            RuleFor(dto => dto.MetaTags)
                .MaximumLength(455).WithMessage("Meta Tags must be 455 characters or less.");
        }
    }

    public class UpdateSEOUrlDTOValidator : AbstractValidator<UpdateSEOUrlDTO>
    {
        public UpdateSEOUrlDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(dto => dto.Url)
                .NotEmpty().WithMessage("Url is required.")
                .MaximumLength(360).WithMessage("Url must be 360 characters or less.");

            RuleFor(dto => dto.RedirectUrl)
                .NotEmpty().WithMessage("RedirectUrl is required.")
                .MaximumLength(1600).WithMessage("RedirectUrl must be 1600 characters or less.");
        }
    }
}
