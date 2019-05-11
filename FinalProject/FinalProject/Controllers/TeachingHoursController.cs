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
    [Authorize(Roles = "Teacher")]
    public class TeachingHoursController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        ApplicationDbContext AppDbContext;

        public TeachingHoursController(UserManager<ApplicationUser> UserManager, ApplicationDbContext AppDbContext)
        {
            this.UserManager = UserManager;
            this.AppDbContext = AppDbContext;
        }

        [HttpGet]
        public IActionResult InsertHours(int? numOfRows)
        {
            InsertHoursViewModel vm = new InsertHoursViewModel();
            if(numOfRows != null)
            {
                vm.NumOfRows = numOfRows.Value;
            }
            return View(vm);
        }

        public async Task<IActionResult> InsertHours(InsertHoursViewModel model)
        {
            if (model.IsDone == false)
            {
                model.NumOfRows++;
                model.IsDone = true;
                return RedirectToAction("InsertHours", new { model.NumOfRows });
            }
            else
            {
                ApplicationUser myUser = await getCurrentUser();
                string id = myUser.Id;
                AppDbContext.InsertLessons(model.AvailList, id);
                return RedirectToAction("Index", "Search");
            }
            
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