using System;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Models
{
    public class BookLibraryDatabaseContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public string DbPath { get; }

        public BookLibraryDatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "book_library.db");
        }

        //boilerplate code sqllite db config
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //map enum Category to string in db
            modelBuilder.Entity<Book>()
                .Property(u => u.Category)
                .HasConversion<string>()
                .HasMaxLength(20);
        }

    }
}

