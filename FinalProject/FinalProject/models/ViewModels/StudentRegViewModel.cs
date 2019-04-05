using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.models.ViewModels
{
    public class StudentRegViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gen { get; set; }
        public string City { get; set; }
        public Education Educ { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int Distance { get; set; }
        public int Price { get; set; }
        public int TeachRanking { get; set; }
        public int NumOfStud { get; set; }
    }
}
