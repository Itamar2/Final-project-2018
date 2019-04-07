using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }
        public double Price { get; set; }
        public string CourseName { get; set; }
        public int NumOfMeetings { get; set; }
        public string CourseDiscription { get; set; }
        //silabus- how to implement
        public string Tid { get; set; }
        [ForeignKey("Tid")]
        public virtual Teacher Teacher { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
