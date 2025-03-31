using Library.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dtos
{
    public class UpdateBookDto
    {
        public string Title { get; set; } = default!;

        public string Isbn { get; set; } = default!;

        public BookStatus Status { get; set; }

    }
}
