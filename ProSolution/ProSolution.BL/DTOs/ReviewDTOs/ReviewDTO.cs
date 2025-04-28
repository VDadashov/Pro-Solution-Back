using FluentValidation;
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
    public class ReviewDTOValidator : AbstractValidator<ReviewDTO>
    {
        public ReviewDTOValidator()
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj bos ola bilmez").MaximumLength(2000).WithMessage("Message maksimum 2000 simvol ola biler.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad bos ola bilmez").MaximumLength(200).WithMessage("Name maksimum 200 simvol ola biler.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email bos ola bilmez").MaximumLength(200).WithMessage("Email maksimum 200 simvol ola biler.");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("BlogId bos ola bilmez");
        }
    }
}
