using Library.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Title { get; set; } = default!;

        [MaxLength(50)]
        public string Isbn { get; set; } = default!;

        public BookStatus Status { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; } = default!;
    }
}
