using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeachingHoursController : Controller
    {
        [HttpGet]
        public IActionResult InsertHours()
        {
            InsertHoursViewModel vm = new InsertHoursViewModel();
            vm.NumOfRows = 1;
            return View(vm);
        }

        [HttpPost]

        public IActionResult InsertHours(InsertHoursViewModel model)
        {
            return null;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}