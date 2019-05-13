using FinalProject.Models;
using FinalProject.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.data
{
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
         * This Extension Method returns a list of a specific Teacher future lessons.
         * Id - Teacher's Id in the Db.
         */
        public static List<Schedule> GetTeacherFutureLessons(this ApplicationDbContext AppDbContext,string Id)
        {
            List<Schedule> myLessons = AppDbContext.Schedules
                .Where(s => s.TeacherId == Id)
                .ToList();
            return myLessons; 
        }
        /**
         * This Extension Method returns a list of a specific Student future lessons.
         * Id - Student Id in the Db.
         */
        public static List<Schedule> GetStudentFutureLessons(this ApplicationDbContext AppDbContext,string Id)
        {
            List<Schedule> myLessons = AppDbContext.Schedules
                .Where(s => s.StudentId == Id)
                .ToList();
            return myLessons;
        }
    }

}
