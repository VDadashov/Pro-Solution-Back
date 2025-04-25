using FluentValidation;
using ProSolution.Business.DTOs.SEODTOs;
using ProSolution.Business.DTOs.SEOUrlDTOs;

namespace ProSolution.Business.Validators.SEOValidator
{
    public class GetByIdSEODTOValidator : AbstractValidator<GetByIdSEODTO>
    {
        public GetByIdSEODTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class GetByIdSEOUrlDTOValidator : AbstractValidator<GetByIdSEOUrlDTO>
    {
        public GetByIdSEOUrlDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class GetByIdSEOMetaDTOValidator : AbstractValidator<GetByIdSEOMetaDTO>
    {
        public GetByIdSEOMetaDTOValidator()
        {
            RuleFor(dto => dto.Id)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Id is required.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
