using Shared.EmailNotifier;

namespace BookStore.Services.Interfaces
{
    public interface IEmailService
    {
        Task<string> ReadTemplate(string messageType);
        Task SendMailAsync(Message message);
        Task SendManyMailAsync(Message message);
    }
}
