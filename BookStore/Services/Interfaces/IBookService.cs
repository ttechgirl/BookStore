using BookStore.DTO;
using BookStore.Services.ServicesResponse;
using BookStore.ViewModels;
using Shared.Extension;

namespace BookStore.Services.Interfaces
{
    public interface IBookService : IServiceResponse
    {
        Task<BookDto> GetByIdAsync(Guid id);   
        Task<List<BookDto>> GetAllBooks();   
        Task<List<BookDto>> FeaturedBooks();   
        Task<Page<BookDto>> FilterBooks(string? name, string? category, int pageIndex = 1, int pageSize = 10);   
        Task<BookDto> AddBooks(BookViewModel model);   
    }
}
