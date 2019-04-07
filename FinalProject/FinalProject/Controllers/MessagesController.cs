using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        ApplicationDbContext AppDbContext;

        public MessagesController(UserManager<ApplicationUser> UserManager, ApplicationDbContext AppDbContext)
        {
            this.UserManager = UserManager;
            this.AppDbContext = AppDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage(string id)
        {
            ApplicationUser OtherUser = await UserManager.FindByIdAsync(id);
            string UserName = User.Identity.Name;
            ApplicationUser MyUser = await UserManager.FindByNameAsync(UserName);

            Message msg = new Message()
            {
                Date = DateTime.Now,
                Content = null,
                RecId = OtherUser.Id,
                SenderId = MyUser.Id,
                IsRead = false
            };
            return null;
        }
    }
}