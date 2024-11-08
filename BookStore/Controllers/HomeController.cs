using BookStore.Models;
using BookStore.Services.Interfaces;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared;
using Shared.Configs;
using Shared.EmailNotifier;
using Shared.Extension;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        public readonly IConfiguration _configuration;
        public readonly IEmailService _emailService;
        public readonly IContactService _contactService;
        public readonly AppSettings _appSettings;
        public HomeController(ILogger<HomeController> logger, IBookService bookservice, IConfiguration configuration, IEmailService emailService, IContactService contactService,IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _bookService = bookservice;
            _configuration = configuration;
            _emailService = emailService;
            _contactService = contactService;
            _appSettings = appSettings.Value;
        }

        public async Task<ActionResult> Index()
        {
            var featuredBooks = await _bookService.FeaturedBooks();
            ViewData["ContactForm"] = new ContactViewModel();

            return View(featuredBooks);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            var getBooks = await _bookService.GetAllBooks();
            return View(getBooks);
        }

        [HttpGet]
        public async Task<ActionResult> GetBookDetails(Guid id)
        {
            var getBook = await _bookService.GetByIdAsync(id);
            if(getBook == null)
            {
                return BadRequest("No record found");
            }
            return View(getBook);
        }

        [HttpGet]
        public async Task<ActionResult> FilterBooks(string? name, string? category, int pageIndex = 1, int pageSize = 10)
        {
            var getBooks = await _bookService.FilterBooks(name,category,pageIndex,pageSize);
            if (getBooks == null)
            {
                return BadRequest("No record found");
            }
            return View(getBooks);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _contactService.SendMessage(model);
                if (response == null)
                {
                    return BadRequest();
                }
                // Process the form data, e.g., save to database, send email, etc.
                await Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        var mailSubject = $"{_configuration.GetSection("EmailConfig")["BookingSubject"]}";

                        var body = await _emailService.ReadTemplate(MessageTypes.SendOrder);

                        var messageToParse = new Dictionary<string, string>
                    {
                        { "{FullName}", response.FullName.ToUpper()},
                        { "{PhoneNumber}", response.PhoneNumber},
                        { "{Email}", response.Email},
                        { "{BookTitle}", response.BookTitle},
                        { "{Message}", response.Message},
                    };

                        //  email notification
                        var messageBody = body.ParseTemplate(messageToParse);
                        var message = new Message(new List<string>() { response.Email }, mailSubject, messageBody);
                        await _emailService.SendMailAsync(message);

                        //  admin email notification
                        var adminMessageBody = body.ParseTemplate(messageToParse);
                        var adminMessage = new Message(_appSettings.AdminTeam.ToList(), mailSubject, adminMessageBody);
                        await _emailService.SendManyMailAsync(adminMessage);

                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message, null);
                        throw;
                    }
                });
                return RedirectToAction("Index");
            }
            return View("Index", model);
            //return View("Index");
        }

        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
