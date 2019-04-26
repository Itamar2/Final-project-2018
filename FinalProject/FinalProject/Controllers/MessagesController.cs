using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.data;
using FinalProject.Models;
using FinalProject.Models.ViewModels;
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
        public IActionResult SendMessage(string id)
        {
            ViewBag.RecId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(MessagesContactsViewModel model)
        {
            ApplicationUser OtherUser = await UserManager.FindByIdAsync(model.OtherId);
            ApplicationUser MyUser = await getCurrentUser();

            Message msg = new Message()
            {
                Date = DateTime.Now,
                Content = model.Message,
                RecId = OtherUser.Id,
                SenderId = MyUser.Id,
                IsRead = false
            };

            AppDbContext.Messages.Add(msg);
            AppDbContext.SaveChanges();
            return RedirectToAction("TalkWith", new { id = msg.RecId});
        }

        [HttpGet]
        public async Task<IActionResult> Conversations()
        {
            ApplicationUser MyUser = await getCurrentUser();
            var myList = AppDbContext.Messages.GetContacts(MyUser.Id);

            return View(myList);
        }
        public async Task<IActionResult> TalkWith(string id)
        {

            ApplicationUser MyUser = await getCurrentUser();
            var Contacts = AppDbContext.Messages.GetContacts(MyUser.Id); //getting contacts the user talked to

            List<Message> msgs = null;

            if(id != null)
            {
                msgs = AppDbContext.Messages.getMessages(MyUser.Id, id); //getting the messages with a specific user.
                AppDbContext.UpdateMsgsToBeSeen(msgs,MyUser.Id); //update the messages to be already watched
            }
            var vm = new MessagesContactsViewModel
            {
                MsgGroup = Contacts,
                Messages = msgs,
                OtherId = id
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> TalkWith(MessagesContactsViewModel model)
        {
            ApplicationUser MyUser = await getCurrentUser();
            var msgs = AppDbContext.Messages.getMessages(MyUser.Id, model.OtherId);
            var vm = new MessagesContactsViewModel
            {
                Messages = msgs
            };
            return View(vm);
        }

        /*
         * This Method return the current Logged-in User.
         **/
        private async Task<ApplicationUser> getCurrentUser()
        {
            //getting the current logged in user
            string UserName = User.Identity.Name;
            ApplicationUser MyUser = await UserManager.FindByNameAsync(UserName);
            return MyUser;
        }
    }
}