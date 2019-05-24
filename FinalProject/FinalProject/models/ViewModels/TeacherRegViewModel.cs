using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class TeacherRegViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Gender Gen { get; set; }
        public Education Educ { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Distance { get; set; }
        public int StudentRanking { get; set; }
        public string AboutMe { get; set; }
        public IFormFile Pic { get; set; }
        public string[] Options { get; set; }
    }
}
