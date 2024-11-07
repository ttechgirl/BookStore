using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = Guid.Parse("EB6CBF99-EA1F-40DC-BB4A-80BBC595D234"),
                    Title = "Book 1",
                    Author = "Author 1",
                    Price = 100.99,
                    CoverImageUrl = "/images/good-paper-wattpad-book.jpg",
                    IsFeatured = true,
                    Category = "Drama"
                },
                new Book
                {
                    Id = Guid.Parse("A885076F-6D95-4B5A-841F-3AFDBD082702"),
                    Title = "Book 2",
                    Author = "Author 2",
                    Price = 200.00,
                    CoverImageUrl = "/images/poster-template-new-scientists.jpg",
                    IsFeatured = true,
                    Category ="Fiction"
                },
                new Book
                {
                    Id = Guid.Parse("BDE62685-6C17-43D1-BCF1-1AF39B2D58FC"),
                    Title = "Book 3",
                    Author = "Author 3",
                    Price = 14.00,
                    CoverImageUrl = "/images/pumpkin-drink-poster.jpg",
                    IsFeatured = true,
                    Category = "Tragedy"
                },
                new Book
                {
                    Id = Guid.Parse("A24A6355-8F92-4857-9B69-211319DBCB1E"),
                    Title = "Book 4",
                    Author = "Author 4",
                    Price = 5.00,
                    CoverImageUrl = "/images/bookcover1.jpg",
                    IsFeatured = true,
                    Category = "Fiction"

                },
                 new Book
                 {
                     Id = Guid.Parse("B12A2281-9DB1-4D3D-9DC4-DE3881FFDF15"),
                     Title = "Book 5",
                     Author = "Author 5",
                     Price = 1409.00,
                     CoverImageUrl = "/images/online-education-poster-template.jpg",
                     IsFeatured = true,
                     Category = "Fiction"
                     

                 },
                new Book
                {
                    Id = Guid.Parse("EE95A674-0C4D-4D3B-B676-4E6E25C03732"),
                    Title = "Book 6",
                    Author = "Author 6",
                    Price = 5.00,
                    CoverImageUrl = "/images/bookcover1.jpg",
                    IsFeatured = true,
                    Category = "Fiction"

                });

        }
    }
}
