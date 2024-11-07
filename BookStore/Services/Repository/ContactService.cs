using BookStore.DTO;
using BookStore.Models;
using BookStore.Services.Interfaces;
using BookStore.Services.ServicesResponse;
using BookStore.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Services.Repository
{
    public class ContactService : ServiceResponse,IContactService
    {
        private readonly AppDbContext _dbContext;

        public ContactService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ContactUsDto> SendMessage(ContactViewModel model)
        {
            var createContact = new ContactUs
            {
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BookTitle = model.BookTitle,
                Message = model.Message,
            };
            var mapModels = createContact.Map();
            await _dbContext.AddAsync(createContact);
            await _dbContext.SaveChangesAsync();
            return mapModels;
        }
    }
}
