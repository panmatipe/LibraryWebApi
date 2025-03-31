using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Repositories
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAll();
        (IEnumerable<Book>, int) GetAll(int? pageSize, int? pageNumber, string? sortBy, bool? isDescending = false);
        Book? GetById(int id);
        int Add(Book book);
        Book Update(Book book);
        void Remove(Book book);
        bool IsUniqueIsbn(string isbn);

    }
}
