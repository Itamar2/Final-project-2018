using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Reccomandation
    {
        public string RedId { get; set; }
        public string Content { get; set; }
        public int Renk { get; set; }
        public DateTime Time { get; set; }
        public string AppId { get; set; }
        [ForeignKey("AppId")]
        public virtual ApplicationUser Sender { get; set; }
        public virtual ApplicationUser Reciver { get; set; }
        [ForeignKey("AppId")]
        public RecType RecType { get; set; }
    }
    public enum RecType
    {
        StuRTe,
        TeRStu
    }
}
