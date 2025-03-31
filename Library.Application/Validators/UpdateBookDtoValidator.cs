using FluentValidation;
using Library.Application.Dtos;

namespace Library.Application.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(dto => dto.Title)
                .NotEmpty()
                    .WithMessage("Book must have a title")
                .MaximumLength(255);

            RuleFor(dto => dto.Isbn)
                .NotEmpty()
                    .WithMessage("ISBN is required")
                .Matches("^(?=(?:\\D*\\d){10}(?:(?:\\D*\\d){3})?$)[\\d-]+$")
                    .WithMessage("ISBN must be a string contains only 10 or 13 digits and hyphens");

            RuleFor(dto => dto.Status)
                .IsInEnum()
                .WithMessage("Status must be a valid BookStatus value (1-4)");

        }
    }
}
