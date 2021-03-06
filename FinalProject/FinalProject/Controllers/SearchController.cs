﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.data;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class SearchController : Controller
    {
        ApplicationDbContext AppDbContext;
        UserManager<ApplicationUser> UserManager;

        public SearchController(ApplicationDbContext AppDbContext, UserManager<ApplicationUser> UserManager)
        {
            this.AppDbContext = AppDbContext;
            this.UserManager = UserManager;
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = AppDbContext.Teachers.Include(x => x.AppUser).ToList();
            ViewBag.NumOfTeachers = teachers.Count;
            return View(teachers);
        }

        public async Task<IActionResult> DisplayProfile(string id)
        {
            ApplicationUser User = await UserManager.FindByIdAsync(id);
            
            return View(User);
        }
    }
}