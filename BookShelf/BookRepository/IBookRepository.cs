using System;
using BookShelf.Models;

namespace BookShelf.BookRepository
{
    public interface IBookRepository
    {
         Task<Book> AddAsync(Book book);
         Task<Book> UpdateAsync(Book book);
        Task<Book> GetBookByIdAsync(Guid bookId);
        Task<List<Book>> GetAllBooksAsync();

    }
}

