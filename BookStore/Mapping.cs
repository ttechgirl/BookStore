using BookStore.DTO;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public static class Mapping
    {

        public static BookDto Map(this Book entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new BookDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Price = entity.Price,
                IsFeatured = entity.IsFeatured,
                CoverImageUrl = entity.CoverImageUrl,
                Category = entity.Category

            };
        }

        public static ContactUsDto Map(this ContactUs entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new ContactUsDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                BookTitle = entity.BookTitle,
                Message = entity.Message,

            };
        }

    }

}


