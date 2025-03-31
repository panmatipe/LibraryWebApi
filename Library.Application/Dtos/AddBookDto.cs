using Library.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Dtos
{
    public class AddBookDto
    {
        public string Title { get; set; } = default!;

        public string Isbn { get; set; } = default!;

        public int? AuthorId {  get; set; }

        public string? AuthorFirstName { get; set; }

        public string? AuthorLastName { get; set; }
    }
}
