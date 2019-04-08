using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class SubField
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Level Level { get; set; }
        public int FieldId { get; set; }
        [ForeignKey("FieldId")]
        public virtual Field Field { get; set; }
    }

    public enum Level
    {
        HighSchool,MiddleSchool,PreSchool,FirstDegree ,MasterDegree
    }
}
