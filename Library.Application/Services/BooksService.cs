using AutoMapper;
using Library.Application.Dtos;
using Library.Application.Exceptions;
using Library.Common;
using Library.Domain.Entities;
using Library.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Library.Application.Services
{
    internal class BooksService(IBooksRepository _booksRepository, ILogger<BooksService> _logger,
        IMapper _mapper) : IBooksService
    {
        public IEnumerable<BookDto> GetAll()
        {
            _logger.LogInformation("Getting all books");
            var books = _booksRepository.GetAll();
            var mappedBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return mappedBooks;
        }

        public IEnumerable<BookDto> GetAll(PaginationQuery query)
        {
            _logger.LogInformation("Getting all books");
            var (books, totalCount) = _booksRepository.GetAll(query.PageSize, query.PageNumber, query.SortBy, query.IsDescending);
            var mappedBooks = _mapper.Map<IEnumerable<BookDto>>(books);
            return mappedBooks;
        }

        public BookDto? GetById(int id)
        {
            _logger.LogInformation($"Getting a book with id {id}");
            var book = _booksRepository.GetById(id);

            if (book is null)
            {
                throw new NotFoundException($"Book with id {id} not found in database.");
            }

            var mappedBook = _mapper.Map<BookDto?>(book);
            return mappedBook;
        }

        public int Add(AddBookDto bookDto)
        {
            _logger.LogInformation("Adding new book");
            var isUniqueIsbn = _booksRepository.IsUniqueIsbn(bookDto.Isbn);

            if (!isUniqueIsbn)
            {
                throw new ItemAlreadyExistsException($"ISBN: '{bookDto.Isbn}' already exists in database.");
            }

            var book = _mapper.Map<Book>(bookDto);
            int id = _booksRepository.Add(book);

            return id;
        }
        public BookDto Update(int id, UpdateBookDto updateBookDto)
        {
            _logger.LogInformation($"Updating a book with id {id}");
            var book = _booksRepository.GetById(id);

            if (book is null)
            {
                throw new NotFoundException($"Book with id {id} not found in database.");
            }

            _mapper.Map(updateBookDto, book);
            _booksRepository.Update(book);
            var updatedBookDto = _mapper.Map<BookDto>(book);

            return updatedBookDto;
        }

        public void Remove(int id)
        {
            _logger.LogInformation($"Deleting a book with id {id}");
            var book = _booksRepository.GetById(id);

            if (book is null)
            {
                throw new NotFoundException($"Book with id {id} not found in database.");
            }

            _booksRepository.Remove(book);
        }
    }
}
