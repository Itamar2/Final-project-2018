using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("SenderId")]
        public virtual ApplicationUser Sender { get; set; }
        [ForeignKey("RecId")]
        public virtual ApplicationUser Recv { get; set; }
        public int SenderId { get; set; }
        public int RecId { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}
