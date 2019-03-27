using System;
using System.Collections.Generic;
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
        public ApplicationUser Sender { get; set; }
        public ApplicationUser Reciver { get; set; }
        [ForeignKey("AppId")]
        public RecType RecType { get; set; }
    }
    public enum RecType
    {
        StuRTe,
        TeRStu
    }
}
