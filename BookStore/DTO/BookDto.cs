namespace BookStore.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; } 
        public string? Title { get; set; }
        public string? Author { get; set; }
        public double Price { get; set; }
        public string? CoverImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
