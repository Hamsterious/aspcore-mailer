using EmailSender.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.ViewComponents
{
    public class EmailViewComponent : ViewComponent
    {
        public EmailViewComponent()
        {
            // USE ME FOR GREATER GOOD! 
            // Like injecting the dbContext or something
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new EmailViewModel() { Message = "Hello World!"};
            return View(viewModel);
        }
    }
}
