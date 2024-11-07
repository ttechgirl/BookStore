using BookStore.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using Shared.Configs;
using Shared.EmailNotifier;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace BookStore.Services.Repository
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly EmailConfig _emailConfig;
        public EmailService(ILogger<EmailService> logger, IOptions<EmailConfig> emailConfig)
        {
            _logger = logger;
            _emailConfig = emailConfig.Value;
        }

        public Task<string> ReadTemplate(string messageType)
        {
            string htmlPath = Path.Combine(AppContext.BaseDirectory, @"wwwroot\html", "_template.html");
            string contentPath = Path.Combine(AppContext.BaseDirectory, @"wwwroot\html", $"{messageType}.txt");
            string html = string.Empty;
            string body = string.Empty;

            // get global html template
            if (File.Exists(htmlPath))
                html = File.ReadAllText(htmlPath);
            else
                return null;

            // get specific Message content
            if (File.Exists(contentPath))
                body = File.ReadAllText(contentPath);
            else return null;

            string msgBody = html.Replace("{body}", body);
            return Task.FromResult(msgBody);
        }
        public async Task SendMailAsync(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.DisplayName, _emailConfig.From));
            //receiver
            foreach (string mailAddress in message.To)
                emailMessage.To.Add(MailboxAddress.Parse(mailAddress));

            var bodyBuilder = new BodyBuilder { HtmlBody = message.Body };
            emailMessage.Body = bodyBuilder.ToMessageBody();
            emailMessage.Subject = message.Subject;

            if (message.FileName != null && message.FileBytes != null)
            {
                var contentType = MimeTypes.GetMimeType(message.FileName);
                bodyBuilder.Attachments.Add(message.FileName, message.FileBytes, ContentType.Parse(contentType));
            }
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig?.Host, _emailConfig.Port, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, ex);
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        public async Task SendManyMailAsync(Message message)
        {
            var emailMessage = new MimeMessage();
            //sender
            emailMessage.From.Add(new MailboxAddress(_emailConfig.DisplayName, _emailConfig.From));

            //receiver
            foreach (string mailAddress in message.To)
                emailMessage.To.Add(MailboxAddress.Parse(mailAddress));

            //Add Content to Mime Message
            var bodyBuilder = new BodyBuilder();
            emailMessage.Subject = message.Subject;
            bodyBuilder.HtmlBody = message.Body;
            emailMessage.Body = bodyBuilder.ToMessageBody();
            if (message.FileName != null && message.FileBytes != null)
            {
                bodyBuilder.Attachments.Add(message.FileName, message.FileBytes, ContentType.Parse("application/pdf"));
            }
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig?.Host, _emailConfig.Port, true);
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
