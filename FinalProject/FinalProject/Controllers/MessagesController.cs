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
    //[Authorize]
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
        public IActionResult SendMessage(string id)
        {
            ViewBag.RecId = id;
            return View();
        }
        [HttpPost]
        public async Task<string> SendMessage(string id, string message)
        {
            ApplicationUser OtherUser = await UserManager.FindByIdAsync(id);
            string UserName = User.Identity.Name;
            ApplicationUser MyUser = await UserManager.FindByNameAsync(UserName);

            /* Message msg = new Message()
            {
                Date = DateTime.Now,
                Content = message,
                RecId = OtherUser.Id,
                SenderId = MyUser.Id,
                IsRead = false
            };
           */
            //AppDbContext.Messages.Add(msg);
            AppDbContext.SaveChanges();
            return "1";
        }

        public async Task<IActionResult> Conversations()
        {
            //getting the current logged in user
            string UserName = User.Identity.Name;
            ApplicationUser MyUser = await UserManager.FindByNameAsync(UserName);
            var messages = AppDbContext.Messages
                .Where(x => x.RecId == MyUser.Id || x.SenderId == MyUser.Id)
                .GroupBy(x => new {x.RecId, x.SenderId});
            
            return View();
        }

        public string a()
        {
            return "blah blah blah";
        }
    }
}