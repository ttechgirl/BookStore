using BookStore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;
using BookStore.ViewModels;
using BookStore.DTO;
using System.ComponentModel.DataAnnotations;
using BookStore.Services.ServicesResponse;
using Shared.Extension;
using BookStore.Models;

namespace BookStore.Services.Repository
{
    public class BookService : ServiceResponse,IBookService
    {
        private readonly AppDbContext _dbContext;
        public BookService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookDto> AddBooks(BookViewModel model)
        {
            var books = await _dbContext.Books.Where(b => b.Title != null).FirstOrDefaultAsync();
            if(books != null)
            {
                Results.Add(new ValidationResult($"Book with same BookTitle exist"));
                return null;
            }
            var createBook = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Price = model.Price,
                IsFeatured = model.IsFeatured,
                CoverImageUrl = model.CoverImageUrl,
                Category = model.Category,
                CreatedOn = DateTime.Now.ToLocalTime(),

            };
            var mapModels = createBook.Map();
            await _dbContext.AddAsync(createBook);
            await _dbContext.SaveChangesAsync();
            return mapModels;
        }

        public async Task<List<BookDto>> FeaturedBooks()
        {
            var books = await _dbContext.Books.Where(b=>b.IsFeatured).ToListAsync();
            if(books ==  null || books.Count == 0)
            {
                Results.Add(new ValidationResult($"No record found"));
                return default;
            }
            var result = books.Select(b => b.Map()).ToList();
            return result;
        }

        public async Task<Page<BookDto>> FilterBooks(string? name, string? category, int pageIndex = 1, int pageSize = 10)
        {
            var getBooks = await _dbContext.Books.Where(b => b.Title == name && b.Category ==category).ToListAsync();
            if (getBooks.Count <= 0)
            {
                Results.Add(new ValidationResult($"No record found"));
                return default;
            }
            var response = getBooks.Select(p => p.Map()).OrderByDescending(p => p.ModifiedOn).ToList();
            var pagedBooks = response.ToPageList(pageIndex, pageSize);
            pagedBooks.Items.ToList();
            return pagedBooks;
        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var books = await _dbContext.Books.ToListAsync();
            if (books == null || books.Count == 0)
            {
                Results.Add(new ValidationResult($"No record found"));
                return default;
            }
            var result = books.Select(b => b.Map()).ToList();
            return result;
        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
             var books = await _dbContext.Books.Where(b => b.Id == id).FirstOrDefaultAsync();
            if (books == null )
            {
                Results.Add(new ValidationResult($"No record found"));
                return null;
            }
            var result = books.Map();
            return result;

        }

    }
}
