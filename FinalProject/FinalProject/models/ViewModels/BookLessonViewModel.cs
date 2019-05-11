using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class BookLessonViewModel
    {
        public List<Schedule> Schedules { get; set; }
        public List<string> AvailableDaysStr { get; set; }
        public List<DateTime> AvailableDaysObj { get; set; }
    }
}
