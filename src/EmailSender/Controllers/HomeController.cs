using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmailSender.ViewComponents;

namespace EmailSender.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
