using BookStore.Services.Interfaces;
using BookStore.Services.Repository;
using BookStore.Services.ServicesResponse;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Configs;

namespace BookStore
{
    public static partial class Startup
    {
        public static WebApplicationBuilder RegisterDI(this WebApplicationBuilder builder)
        {
            //add services
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IServiceResponse, ServiceResponse>();

            // configurations
            //builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection(nameof(EmailConfig)));
            builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


            // For Entity Framework
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            return builder;
        }
    }
}
