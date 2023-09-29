using System;
using BookShelf.BookRepository;
using BookShelf.Models;

namespace BookShelf.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateBook(Book newBook)
        {
            newBook.RegistrationTimeStamp = DateTimeOffset.Now;
            var createdBook = await _bookRepository.AddAsync(newBook);
            return createdBook;
        }

        public async Task<Book> UpdateBook(Book newBook)
        {
            var updatedBook = await _bookRepository.UpdateAsync(newBook);
            return updatedBook;
        }

        public async Task<List<Book>> GetAllBooks() {
            List<Book> AllBooks = await _bookRepository.GetAllBooksAsync();
            return AllBooks;
        }
    }
}

