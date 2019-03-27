﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }
        [ForeignKey("RecId")]
        public ApplicationUser Recv { get; set; }
        public int SenderId { get; set; }
        public int RecId { get; set; }
        public bool IsRead { get; set; }
        public string Content { get; set; }
    }
}