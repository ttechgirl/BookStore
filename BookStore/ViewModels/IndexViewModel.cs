using BookStore.DTO;

namespace BookStore.ViewModels
{
    public class IndexViewModel
    {
        public List<BookDto> Books { get; set; }
        public ContactViewModel ContactForm { get; set; } = new ContactViewModel(); // Initialize to avoid null reference issues
    }

}
