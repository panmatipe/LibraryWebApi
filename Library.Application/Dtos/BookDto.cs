using Library.Common.Enums;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;

        public string Isbn { get; set; } = default!;

        public BookStatus Status { get; set; }

        public int AuthorId { get; set; }

        public string AuthorFirstName { get; set; } = default!;

        public string AuthorLastName { get; set; } = default!;
    }
}
