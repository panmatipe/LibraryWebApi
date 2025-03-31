using Library.Common.Enums;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Library.Infrastructure.Repositories
{
    internal class BooksRepository(BooksContext _dbContext) : IBooksRepository
    {
        public int Add(Book book)
        {
            book.Status = BookStatus.OnTheShelf;
            if (book.AuthorId != 0)
            {
                book.Author = null; // To not override author accidentally
            }
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public Book Update(Book book)
        {
            _dbContext.Books.Update(book);
            _dbContext.SaveChanges();

            return book;
        }

        public (IEnumerable<Book>, int) GetAll(int? pageSize, int? pageNumber, string? sortBy, bool? isDescending = false)
        {
            var booksQuery = _dbContext.Books
                .Include(k => k.Author).Select(k => k);

            var totalCount = booksQuery.Count();

            if (sortBy != null)
            {
                var columnsSelector = new Dictionary<string, Expression<Func<Book, object>>>
                {
                    { nameof(Book.Title), r => r.Title },
                    { nameof(Book.Author.FirstName), r => r.Author.FirstName },
                    { nameof(Book.Author.LastName), r => r.Author.LastName },
                };

                //columnsSelector.TryGetValue(sortBy, out Expression<Func<Book, object>> selectedColumn);
                var selectedColumn = columnsSelector[sortBy];

                booksQuery = isDescending.HasValue && isDescending.Value
                    ? booksQuery.OrderByDescending(selectedColumn)
                    : booksQuery.OrderBy(selectedColumn);
            }

            List<Book>? booksList = new();

            if (pageSize.HasValue && pageSize.Value > 0 && pageNumber.HasValue && pageNumber.Value > 0)
            {
                booksList = booksQuery
                    .Skip(pageSize.Value * (pageNumber.Value - 1))
                    .Take(pageSize.Value)
                    .ToList();
            }
            else
            {
                booksList = booksQuery.ToList();
            }

            return (booksList, totalCount);
        }


        public IEnumerable<Book> GetAll()
        {
            var books = _dbContext.Books
                .Include(k => k.Author)
                .ToList();
            return books;
        }

        public Book? GetById(int id)
        {
            var books = _dbContext.Books
                .Include(k => k.Author)
                .FirstOrDefault(k => k.Id == id);

            return books;
        }

        public void Remove(Book book)
        {
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }

        public bool IsUniqueIsbn(string isbn)
        {
            var result = _dbContext.Books.Any(x => x.Isbn == isbn);
            return !result;
        }
    }
}
