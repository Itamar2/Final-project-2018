using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.data
{
    public class MessageGroup
    {
        public ApplicationUser OtherUser { get; set; }
        public DateTime Date { get; set; }
        public int numOfUnreadMsgs { get; set; }
    }
}
