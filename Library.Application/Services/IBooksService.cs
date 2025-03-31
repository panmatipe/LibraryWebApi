using Library.Application.Dtos;
using Library.Common;
using Library.Domain.Entities;

namespace Library.Application.Services
{
    public interface IBooksService
    {
        IEnumerable<BookDto> GetAll();
        IEnumerable<BookDto> GetAll(PaginationQuery query);
        BookDto? GetById(int id);
        int Add(AddBookDto book);
        BookDto Update(int id, UpdateBookDto book);
        void Remove(int id);
    }
}