using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public Gender Gen { get; set; }
        public Education Educ { get; set; }
        public int Distance { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Education
    {
        None,
        High_School,
        Academic
    }
}
