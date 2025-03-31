using FluentValidation;
using Library.Application.Dtos;

namespace Library.Application.Validators
{
    public  class AddBookDtoValidator : AbstractValidator<AddBookDto>
    {
        public AddBookDtoValidator()
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

            RuleFor(x => x)
                //.Custom((value, context)=>
                //{
                //    context.AddFailure("No author");
                //})
                .Must(dto =>
                    (dto.AuthorId.HasValue && dto.AuthorId.Value > 0) ||
                    (!string.IsNullOrWhiteSpace(dto.AuthorFirstName) && !string.IsNullOrWhiteSpace(dto.AuthorLastName)))
                .WithMessage("Either AuthorId must be provided or both AuthorFirstName and AuthorLastName must be provided");
        }
    }
}
