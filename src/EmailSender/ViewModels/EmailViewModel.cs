using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailSender.ViewModels
{
    public class EmailViewModel
    {
        public string RecieverEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
