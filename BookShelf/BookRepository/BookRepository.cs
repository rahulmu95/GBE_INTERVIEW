using System;
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.BookRepository
{
    public class BookRepository:IBookRepository
    {
        private readonly BookLibraryDatabaseContext _context;
        private readonly DbSet<Book> _books;

        public BookRepository(BookLibraryDatabaseContext context)
        {
            this._context = context;
            _books = context.Set<Book>();
        }

        public async Task<Book> AddAsync(Book book)
        {
            book.Id = Guid.NewGuid();
            await _books.AddAsync(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            if (book == null)
            {
                return null;
            }

            _books.Attach(book);
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            return await _books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == bookId);

        }

        public async Task<List<Book>> GetAllBooksAsync() {
            return await _books.AsNoTracking().ToListAsync();
        }
    }
}

