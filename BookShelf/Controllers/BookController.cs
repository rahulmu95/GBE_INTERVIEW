using System;
using BookShelf.BookRepository;
using BookShelf.Dto;
using BookShelf.Models;
using BookShelf.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        private readonly IBookRepository _bookRepository;

        public BookController(BookService bookService, IBookRepository bookRepository)
        {
            _bookService = bookService;
            _bookRepository = bookRepository;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewBook([FromBody] Book newBook)
        {
            if (newBook == null || newBook.Author == "" || newBook.Name == "")
            {
                return BadRequest("Invalid data");
            }
            var createdBook = await _bookService.CreateBook(newBook);

            return Ok(createdBook);
        }

        [HttpPut("{bookId}/update")]
        public async Task<IActionResult> UpdateBook(Guid bookId, [FromBody] UpdateBookRequestDto updateBookRequest)
        {
            Book existingBook = await _bookRepository.GetBookByIdAsync(bookId);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Author = updateBookRequest.Author == null || updateBookRequest.Author == "" ? existingBook.Author : updateBookRequest.Author;
            existingBook.Name = updateBookRequest.Name == null || updateBookRequest.Name == "" ? existingBook.Name : updateBookRequest.Name;
            existingBook.Category = updateBookRequest.Category == null ? existingBook.Category : updateBookRequest.Category.Value;
            existingBook.Description = updateBookRequest.Description == null || updateBookRequest.Description == "" ? existingBook.Description : updateBookRequest.Description;
            var updatedBook = await _bookService.UpdateBook(existingBook);
            return Ok(updatedBook);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllBooks()
        {
           
            var allBooks = await _bookService.GetAllBooks();
            return Ok(allBooks);
        }
    }
    }


