using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models.Teacher;

namespace FinalProject.Models
{
    public class Course
    {
        [key]
        public string CourseId { get; set; }
        public double Price { get; set; }
        public string CourseName { get; set; }
        public int NumOfMeetings { get; set; }
        public string CourseDiscription { get; set; }
        //silabus- how to implement
        public string Tid { get; set; }
        [ForeignKey("Tid")]
        public Teacher Teacher { get; set; }
        public List<Course> Courses { get; set; }
    }
}
