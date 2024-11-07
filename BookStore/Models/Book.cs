namespace BookStore.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string? Title { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public string? CoverImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; } = DateTime.Now;
    }
}
