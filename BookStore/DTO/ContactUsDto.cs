namespace BookStore.DTO
{
    public class ContactUsDto
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BookTitle { get; set; }
        public string? Message { get; set; }
    }
}
