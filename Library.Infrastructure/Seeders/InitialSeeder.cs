using Library.Common.Enums;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Seeders
{
    internal class InitialSeeder(BooksContext _dbContext) : IInitialSeeder
    {
        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.Books.Any())
                {
                    //await _dbContext.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('[LibraryDB].[dbo].[Author]', RESEED, 0);");
                    //await _dbContext.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('[LibraryDB].[dbo].[Books]', RESEED, 0);");
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<Book> GetBooks()
        {
            // Create authors
            var author1 = new Author
            {
                FirstName = "John",
                LastName = "Doe",
                Books = new List<Book>()
            };

            var author2 = new Author
            {
                FirstName = "Jane",
                LastName = "Smith",
                Books = new List<Book>()
            };

            var author3 = new Author
            {
                FirstName = "Robert",
                LastName = "Johnson",
                Books = new List<Book>()
            };

            // Create books and assign authors
            var books = new List<Book>
            {
                new Book
                {
                    Title = "C# Fundamentals",
                    Isbn = "978-1-56619-011-1",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author1.Id,
                    Author = author1
                },
                new Book
                {
                    Title = "Advanced C#",
                    Isbn = "978-1-56619-011-2",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author1.Id,
                    Author = author1
                },
                new Book
                {
                    Title = "Entity Framework Core",
                    Isbn = "978-1-56619-011-3",
                    Status = BookStatus.Borrowed,
                    AuthorId = author2.Id,
                    Author = author2
                },
                new Book
                {
                    Title = "ASP.NET Core Guide",
                    Isbn = "978-1-56619-011-4",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author2.Id,
                    Author = author2
                },
                new Book
                {
                    Title = "LINQ in Action",
                    Isbn = "978-1-56619-011-5",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author3.Id,
                    Author = author3
                },
                new Book
                {
                    Title = "Microservices Architecture",
                    Isbn = "978-1-56619-011-6",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author3.Id,
                    Author = author3
                },
                new Book
                {
                    Title = "Clean Code",
                    Isbn = "978-1-56619-011-7",
                    Status = BookStatus.Borrowed,
                    AuthorId = author3.Id,
                    Author = author3
                },
                new Book
                {
                    Title = "Refactoring",
                    Isbn = "978-1-56619-011-8",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author1.Id,
                    Author = author1
                },
                new Book
                {
                    Title = "Design Patterns",
                    Isbn = "978-1-56619-011-9",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author2.Id,
                    Author = author2
                },
                new Book
                {
                    Title = "Software Architecture",
                    Isbn = "978-1-56619-011-0",
                    Status = BookStatus.OnTheShelf,
                    AuthorId = author3.Id,
                    Author = author3
                }
            };

            return books;
        }
    }
}
