using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;

namespace FinalProject.Models
{
    public class Group
    {
        public string GroupId { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        //  public DateTime SincTime { get; set; }
        public GroupType GroupType { get; set; }
        public string GroupName { get; set; }
        public int MinStu { get; set; }
        public int MaxStu { get; set; }
        public string Courseid { get; set; }
        [ForeignKey("Courseid")]
        public Course Course { get; set; }
        //connect to calender
    }
    public enum GroupType
    {
        Private,
        Group                         
    }
}
