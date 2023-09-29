using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShelf.Models
{
    [Table("book")]
    public class Book
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("author")]
        public string Author { get; set; }
        [Column("registration_timestamp")]
        public DateTimeOffset RegistrationTimeStamp { get; set; }
        [Column("category")]
        public Category Category { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }

    public enum Category {
        Thriller,
        History,
        Drama,
        Biography
    }
}

