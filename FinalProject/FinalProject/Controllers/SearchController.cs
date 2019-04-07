using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class SearchController : Controller
    {
        ApplicationDbContext AppDbContext;

        public SearchController(ApplicationDbContext AppDbContext)
        {
            this.AppDbContext = AppDbContext;
        }

        public IActionResult Index()
        {
            List<Teacher> teachers = AppDbContext.Teachers.Include(x => x.AppUser).ToList();
            ViewBag.NumOfTeachers = teachers.Count;
            return View(teachers);
        }
    }
}