using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public int Price { get; set; }
        public int TeacherRanking { get; set; }
        public int NumOfStu { get; set; }
        public string AppId { get; set; }
        [ForeignKey("AppId")]
        public virtual ApplicationUser AppUser { get; set; }
    }
}
