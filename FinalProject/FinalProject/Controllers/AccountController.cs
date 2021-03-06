﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.data;
using FinalProject.Models;
using FinalProject.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> UserManager;
        ApplicationDbContext AppDbContext;
        SignInManager<ApplicationUser> SignInMan;
        IHostingEnvironment he;

        public AccountController(UserManager<ApplicationUser> UserManager, ApplicationDbContext AppDbContext, SignInManager<ApplicationUser> SignInMan, IHostingEnvironment he)
        {
            this.UserManager = UserManager;
            this.AppDbContext = AppDbContext;
            this.SignInMan = SignInMan;
            this.he = he;
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
            var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(model.Pic.FileName));
            model.Pic.CopyTo(new FileStream(fileName, FileMode.Create));
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
                Educ = model.Educ,
                PicPath = fileName
            };

            Student st = new Student()
            {
                Price = model.Price,
                TeacherRanking = model.TeachRanking,
                NumOfStu = model.NumOfStud,
                AppId = myUser.Id
            };

            
            var result = await UserManager.CreateAsync(myUser, model.Password);
            var resultRole = await UserManager.AddToRoleAsync(myUser, "Student");

            if (result.Succeeded)
            {
                AppDbContext.Students.Add(st);
                AppDbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("RegisterStudent");
        }

        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(TeacherRegViewModel model)
        {
            var fileName = Path.Combine(he.WebRootPath,Path.GetFileName(model.Pic.FileName));
            model.Pic.CopyTo(new FileStream(fileName,FileMode.Create));
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
                Educ = model.Educ,
                PicPath = model.Pic.FileName
            };
            Teacher teacher;
            var result = await UserManager.CreateAsync(myUser, model.Password);
            await UserManager.AddToRoleAsync(myUser, "Teacher");

            if (result.Succeeded)
            {
                teacher = new Teacher()
                {
                    StudentRanking = model.StudentRanking,
                    AboutMe = model.AboutMe,
                    AppId = myUser.Id
                };
                AppDbContext.Teachers.Add(teacher);
                AppDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string UserName,string Password,bool RemeberMe)
        {
            var result = await SignInMan.PasswordSignInAsync(UserName,Password,/*model.RememberMe*/true, true);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await SignInMan.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}