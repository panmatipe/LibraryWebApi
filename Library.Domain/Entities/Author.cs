using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; } = default!;

        [MaxLength(255)]
        public string LastName { get; set; } = default!;

        public ICollection<Book>? Books { get; set; }
    }
}
