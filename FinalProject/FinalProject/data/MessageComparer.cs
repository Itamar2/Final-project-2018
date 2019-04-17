using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.data
{
    public class MessageComparer : IEqualityComparer<ApplicationUser>
    {

        public bool Equals(ApplicationUser x, ApplicationUser y)
        {
            return x.Id == y.Id ? true : false;
        }
        public int GetHashCode(ApplicationUser User)
        {
            return User.Id.GetHashCode();
        }
    }
}
