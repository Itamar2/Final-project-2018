using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.data
{
    /*
     * this class defines extension method to IQueryable<Message>.
     * here we'll define Message Queries to our Messaged unit.
     **/
    public static class MessageQueries
    {
        public static IQueryable<MessageGroup> GetContacts(this IQueryable<Message> Messages,string myId)
        {

            var result =
                Messages
                .Where(m => m.SenderId == myId || m.RecId == myId)
                .GroupBy(
                    keySelector: m => m.SenderId == myId ? m.Recv : m.Sender,
                    resultSelector: (key, msgs) => new MessageGroup
                    {
                        OtherUser = key,
                        Date = msgs.OrderByDescending(m => m.Date).First().Date,
                        numOfUnreadMsgs = msgs.numOfNewMsgsSpecUser(myId, key.Id)
                    }
                    );

            return result;
        }

        public static List<Message> getMessages(this IQueryable<Message> Messages,string myId,string otherId)
        {
            var result = Messages
                .Where(m => m.SenderId == myId && m.RecId == otherId || m.SenderId == otherId && m.RecId == myId)
                .OrderBy(m => m.Date);
            return result.ToList();
        }

        public static int numOfNewMsgs(this IQueryable<Message> Messages,string myId)
        {
            int num = Messages
                .Where(m => (m.RecId == myId) && (m.IsRead == false))
                .Count();
            return num;
        }

        public static int numOfNewMsgsSpecUser(this IEnumerable<Message> Messages,string myId,string otherId)
        {
            int num = Messages
                .Where(m => (m.RecId == myId) && (m.SenderId == otherId) && (m.IsRead == false))
                .Count();
            return num;
        }

        public static void UpdateMsgsToBeSeen(this ApplicationDbContext AppDbContext, List<Message> msgs,string myId)
        {
            foreach (var msg in msgs)
            {
                if(msg.RecId == myId && msg.IsRead == false)
                {
                    msg.IsRead = true;
                    AppDbContext.Update(msg);
                }

            }
            AppDbContext.SaveChanges();
        }
    }
}

//var result =
//    Messages
//    .Where(m => m.SenderId == myId || m.RecId == myId)
//    .GroupBy(
//        keySelector: m => new MessageKey
//        {
//            SenderId = m.SenderId,
//            RecId = m.RecId
//        },
//        elementSelector: m => m,
//        resultSelector: (msgKey, msgs) => new MessageGroup
//        {
//            Recent = msgs.OrderByDescending(m => m.Date).First().Date,
//            OtherUser = (msgs.First().SenderId == myId) ? msgs.First().RecId : msgs.First().SenderId

//        },
//        comparer: new MessageComparer(myId)
//        )
//        .OrderBy(g => g.Recent)
//        .Select(g => g.OtherUser)
//        .ToList();


//var result =
//    Messages
//    .Where(m => m.SenderId == myId || m.RecId == myId)
//    .GroupBy
//    (
//        keySelector: m => (m.SenderId == myId) ? m.Recv : m.Sender,
//        resultSelector: (key, msgs) => new MessageGroup
//        {
//            OtherUser = key,
//            Recent = msgs.OrderByDescending(m => m.Date).First().Date
//        },
//        comparer: new MessageComparer()
//    )
//    .OrderBy(g => g.Recent)
//    .Select(g => g.OtherUser);

//return result.ToList();