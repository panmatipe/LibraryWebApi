using Library.Application.Dtos;
using Library.Application.Services;
using Library.Common;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBooksService _booksService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPaginated([FromQuery] PaginationQuery query)
        {
            var books = _booksService.GetAll(query);
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book =  _booksService.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook(AddBookDto? bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest();
            }

            int id =  _booksService.Add(bookDto);

            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, UpdateBookDto? bookDto)
        {
            if (bookDto == null)
            {
                return BadRequest();
            }

            var result = _booksService.Update(id, bookDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook([FromRoute] int id)
        {
            _booksService.Remove(id);

            return Ok();
        }
    }
}
