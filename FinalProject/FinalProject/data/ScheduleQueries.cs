using FinalProject.Models;
using FinalProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.data
{
    /**
     * This Class adds extension methods to ApplicationDbContext object which add
     * queries about schedules in our website.
     */ 
    public static class ScheduleQueries
    {
        public static void InsertLessons(this ApplicationDbContext AppDbContext,List<AvailHours> Lessons,string Id)
        {
            foreach (var Lesson in Lessons)
            {
                TimeSpan Interval = Lesson.FinishHour - Lesson.StartHour;
                int Hours = Interval.Hours;

                for(int i = 0; i < Hours; i++)
                {
                    Schedule Sched = new Schedule()
                    {
                        Date = new DateTime(Lesson.Date.Year, Lesson.Date.Month, Lesson.Date.Day, 0, 0, 0),
                        Start = Lesson.StartHour.AddHours(i),
                        Finish = Lesson.StartHour.AddHours(i+1),
                        IsTaken = false,
                        TeacherId = Id
                    };
                    AppDbContext.Schedules.Add(Sched);
                }
            }
            AppDbContext.SaveChanges();
        }

        /**
         * This Extension Method returns a list of the Hours a specific teacher teaches on a specific date.
         * Id - the Id of the requested teacher.
         * myDate - the date.
         */ 
        public static List<Schedule> GetAvailableHours(this ApplicationDbContext AppDbContext,string Id,DateTime myDate)
        {
            List<Schedule> Schedules = AppDbContext.Schedules
                .Where(s => s.TeacherId == Id && s.Date.Date == myDate.Date)
                .ToList();
            return Schedules;
        }

        /**
         * This extension Method returns a list of Dates The teacher who have the Id teaches.
         * Id - the Id of the requested teacher.
         */
        public static List<DateTime> GetAvailableDays(this ApplicationDbContext AppDbContext,string Id)
        {
            List<DateTime> myList = AppDbContext.Schedules
                .Where(s => s.TeacherId == Id)
                .Select(s => s.Date)
                .Distinct()
                .ToList();
            return myList;
        }

        /**
         * This extension method returns a list of future lessons a student or teacher have.
         * Id - the Id of the requested teacher or student.
         */
        public static List<SchedGroup> getFutureLessons(this ApplicationDbContext AppDbContext,string id,bool future)
        {
            DateTime myTime = DateTime.Now;

            IQueryable<Schedule> lessons;

           if (future) // the user wants lessons that haven't happened yet.
            {
                lessons = AppDbContext.Schedules
                .Where(s => (s.TeacherId == id || s.StudentId == id) && s.Start >= myTime && s.IsTaken == true);
            }
            else // the user wants lessons that already took place.
            {
                lessons = AppDbContext.Schedules
                .Where(s => (s.TeacherId == id || s.StudentId == id) && s.Start < myTime && s.IsTaken == true);
            }
            
            List<SchedGroup> myLessons = lessons
                .GroupBy
                (
                keySelector: s => s.Start.Date, // group lessons by the start date ignoring hours.
                elementSelector: s => s, // leave each element as it is right now.
                resultSelector: (myKey, Scheds) => new SchedGroup() //each group in the list will be in this form.
                {
                    Key = myKey, // the date that our group is based on.
                    Schedules = Scheds.OrderBy(s => s.Start) // elements in the group.
                }
                )
                .OrderBy(g => g.Key)
                .ToList();
            return myLessons;
        }
    }


    public class SchedGroup
    {
        public DateTime Key { get; set; } //the date that the group is based on.
        public IEnumerable<Schedule> Schedules { get; set; } // the lessons that accurs in that date.
    }

}
