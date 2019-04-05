using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.data;
using FinalProject.models;
using FinalProject.models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        ApplicationDbContext AppDbContext;
        SignInManager<ApplicationUser> SignInMan;

        public AccountController(UserManager<ApplicationUser> UserManager, ApplicationDbContext AppDbContext, SignInManager<ApplicationUser> SignInMan)
        {
            this.UserManager = UserManager;
            this.AppDbContext = AppDbContext;
            this.SignInMan = SignInMan;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterStudent(StudentRegViewModel model)
        {
            ApplicationUser myUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Gen = model.Gen,
                City = model.City,
                Distance = model.Distance,
                Educ = model.Educ
            };

            Student st = new Student()
            {
                Price = model.Price,
                TeacherRanking = model.TeachRanking,
                NumOfStu = model.NumOfStud,
                AppId = myUser.Id
            };

            
            var result = await UserManager.CreateAsync(myUser, model.Password);
            var resultRole = await UserManager.AddToRoleAsync(myUser, "student");

            if (result.Succeeded)
            {
                AppDbContext.Students.Add(st);
                AppDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(TeacherRegViewModel model)
        {
            ApplicationUser myUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Gen = model.Gen,
                City = model.City,
                Distance = model.Distance,
                Educ = model.Educ
            };

            Teacher teacher = new Teacher()
            {
                StudentRanking = model.StudentRanking,
                AppId = myUser.Id
            };

            var result = await UserManager.CreateAsync(myUser, model.Password);
            await UserManager.AddToRoleAsync(myUser, "teacher");

            if (result.Succeeded)
            {
                AppDbContext.Teachers.Add(teacher);
                AppDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            var result = await SignInMan.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMan.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}