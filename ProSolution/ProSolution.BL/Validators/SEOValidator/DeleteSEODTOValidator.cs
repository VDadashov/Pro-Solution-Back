using FluentValidation;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Business.DTOs.SEOUrlDTOs;

namespace ProSolution.Business.Validators.SEOValidator
{
    public class DeleteSEODTOValidator : AbstractValidator<DeleteSEODTO>
    {
        public DeleteSEODTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class DeleteSEOUrlDTOValidator : AbstractValidator<DeleteSEOUrlDTO>
    {
        public DeleteSEOUrlDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class DeleteSEOMetaDTOValidator : AbstractValidator<DeleteSEOMetaDTO>
    {
        public DeleteSEOMetaDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
