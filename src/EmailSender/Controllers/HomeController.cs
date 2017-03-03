using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmailSender.ViewComponents;
using EmailSender.Services;
using EmailSender.ViewModels;

namespace EmailSender.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var viewModel = new EmailViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EmailViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _emailService.SendEmailAsync(viewModel.RecieverEmail, viewModel.Subject, viewModel.Message);
            }

            return View(viewModel);
        }

        public IActionResult Email()
        {
            return ViewComponent(nameof(Email));
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
