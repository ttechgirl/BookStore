using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "FullName is  required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Email is  required"), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is  required"), DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "BookTitle is  required")]
        public string? BookTitle { get; set; }
        [Required(ErrorMessage = "Message is  required")]
        public string? Message { get; set; }
    }
}
