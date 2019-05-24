using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.data
{     /*
       * This Class is responsible for normelizing the data in order to
       * perform our search engine.
       */
    public static class Normalizer
    {
        public static int NormDistance(int stuDist,int teacDist)
        {
            return ((1 / teacDist) / stuDist) * (25 / (1 / stuDist));
        }

        public static int NormPrice(int studPrice,int teachPrice)
        {
            return NormDistance(studPrice, teachPrice);
        }


        // teacherRanking - actual teacher ranking 1-5
        //studRanking - student wishes for teacher
        public static int NormTeacherRanking(int teacherRanking,int studRanking)
        {
            return (teacherRanking > studRanking) ? 25 : (teacherRanking / studRanking) * 25;
        }

        // teacherNumOfStudent - number of students the teacher already taught.
        public static int NormNumOfStudents(int teacherNumOfStudent,int studNumOfStud)
        {
            return NormTeacherRanking(teacherNumOfStudent,studNumOfStud);
        }
    }
}
