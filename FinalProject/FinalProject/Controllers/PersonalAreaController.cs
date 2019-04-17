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
    public class PersonalAreaController : Controller
    {

        UserManager<ApplicationUser> UserManager;
        ApplicationDbContext AppDbContext;

        public PersonalAreaController(UserManager<ApplicationUser> UserManager, ApplicationDbContext AppDbContext)
        {
            this.UserManager = UserManager;
            this.AppDbContext = AppDbContext;
        }
        public async Task<IActionResult> Index()
        {
            //getting the current logged in user
            string UserName = User.Identity.Name;
            ApplicationUser MyUser = await UserManager.FindByNameAsync(UserName);
            int num = AppDbContext.Messages.numOfNewMsgs(MyUser.Id);
            ViewBag.numOfNewMsgs = num;
            return View();
        }
    }
}