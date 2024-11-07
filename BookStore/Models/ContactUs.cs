namespace BookStore.Models
{
    public class ContactUs
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BookTitle { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
