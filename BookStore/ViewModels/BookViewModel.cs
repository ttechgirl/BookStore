using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookViewModel
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public bool IsFeatured { get; set; }
        public string? Category { get; set; }
        public string? CoverImageUrl { get; set; }

        public static explicit operator BookViewModel(Book source)
        {
            var destination = new BookViewModel();
            destination.Title = source.Title;
            destination.Author = source.Author;
            destination.Price = source.Price;
            destination.CoverImageUrl = string.IsNullOrWhiteSpace(source.CoverImageUrl) ? null : source.CoverImageUrl;
            return destination;
        }

        public static explicit operator Book(BookViewModel source)
        {
            var destination = new Book();
            destination.Title = source.Title;
            destination.Author = source.Author;
            destination.Price = source.Price;
            destination.CoverImageUrl = source.CoverImageUrl;
            return destination;
        }
    }
}
