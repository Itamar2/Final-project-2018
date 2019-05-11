using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        [ForeignKey("TeacherId")]
        public virtual ApplicationUser Teacher { get; set; }
        [ForeignKey("StudentId")]
        public virtual ApplicationUser Student { get; set; }
        public string TeacherId { get; set; }
        public string StudentId { get; set; }
        public bool IsTaken { get; set; }
    }
}
