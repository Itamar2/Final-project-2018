using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.models
{
    public class Teacher
    {
        [Key]
        public int Tid { get; set; }
        public int StudentRanking { get; set; }
        public string AppId { get; set; }
        [ForeignKey("AppId")]
        public ApplicationUser AppUser { get; set; }
    }
}
