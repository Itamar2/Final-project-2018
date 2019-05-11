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
    public class BookLessonController : Controller
    {

        UserManager<ApplicationUser> UserManager;
        ApplicationDbContext AppDbContext;

        public BookLessonController(UserManager<ApplicationUser> UserManager, ApplicationDbContext AppDbContext)
        {
            this.UserManager = UserManager;
            this.AppDbContext = AppDbContext;
        }
        
        [HttpGet]
        public async Task<IActionResult> AvailableLessons(string Teacher,DateTime? ReqDate)
        {
            ApplicationUser MyTeacher = await UserManager.FindByIdAsync(Teacher);
            BookLessonViewModel vm = null;

            if (MyTeacher != null)
            {
                if(ReqDate == null)
                {
                    ReqDate = DateTime.Now;
                }
                ViewBag.TeacherId = Teacher;
                List<Schedule> Schedules = AppDbContext.GetAvailableHours(MyTeacher.Id, ReqDate.Value);
                List<DateTime> AvailableDays = AppDbContext.GetAvailableDays(MyTeacher.Id);
                vm = new BookLessonViewModel()
                {
                    Schedules = Schedules,
                    AvailableDaysObj = AvailableDays,
                    AvailableDaysStr = AvailableDays.ConvertAll(d => d.ToString("dddd, dd MMMM yyyy"))
                };

            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> BookLesson(int id)
        {
            ApplicationUser myUser = await getCurrentUser();

            Schedule Sched = AppDbContext.Schedules.Find(id);
            return View(Sched);
        }

        [HttpPost,ActionName("BookLesson")]
        public async Task<IActionResult> BookLessonConfirmed(Schedule Sched)
        {
            ApplicationUser myUser = await getCurrentUser();
            Schedule S = AppDbContext.Schedules.Find(Sched.Id);
            if(S != null)
            {
                S.IsTaken = true;
                S.StudentId = myUser.Id;
                AppDbContext.Schedules.Update(S);
                AppDbContext.SaveChanges();
            }
            return RedirectToAction("Index","Search");
        }
        private async Task<ApplicationUser> getCurrentUser()
        {
            //getting the current logged in user
            string UserName = User.Identity.Name;
            ApplicationUser MyUser = await UserManager.FindByNameAsync(UserName);
            return MyUser;
        }
    }
}