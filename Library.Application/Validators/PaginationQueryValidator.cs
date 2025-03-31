using FluentValidation;
using Library.Common;
using Library.Domain.Entities;

namespace Library.Application.Validators
{
    public class PaginationQueryValidator : AbstractValidator<PaginationQuery>
    {
        private int[] allowPageSizes = [5, 10, 15, 30];
        private string[] allowedSortByColumnNames = [nameof(Book.Title),
        nameof(Book.Author.FirstName),
        nameof(Book.Author.LastName)];


        public PaginationQueryValidator()
        {
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(r => r.SortBy)
                .Must(value => allowedSortByColumnNames.Contains(value))
                .When(q => q.SortBy != null)
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
