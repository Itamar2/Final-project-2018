using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class MessagesContactsViewModel
    {
        public List<ApplicationUser> Contacts { get; set; }
        public List<Message> Messages { get; set; }
    }
}
