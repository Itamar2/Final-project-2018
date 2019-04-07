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
        public IActionResult SendMessage(string id)
        {
            return null;
        }
    }
}