using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Field
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public virtual List<SubField> SubFields { get; set; }

    }
}
