using System;
using BookShelf.Models;

namespace BookShelf.Dto
{
    public class UpdateBookRequestDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public Category? Category { get; set; }

    }
}

