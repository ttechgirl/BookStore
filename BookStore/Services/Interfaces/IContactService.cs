using BookStore.DTO;
using BookStore.Services.ServicesResponse;
using BookStore.ViewModels;

namespace BookStore.Services.Interfaces
{
    public interface IContactService :IServiceResponse
    {
        Task<ContactUsDto> SendMessage(ContactViewModel model);

    }
}
