using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models.ViewModels
{
    public class InsertHoursViewModel
    {
        public int NumOfRows{ get; set; }
        public bool IsDone { get; set; }
        public List<AvailHours> AvailList { get; set; }
    }

    public class AvailHours
    {
        public DateTime Date { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime FinishHour { get; set; }
    }
}
