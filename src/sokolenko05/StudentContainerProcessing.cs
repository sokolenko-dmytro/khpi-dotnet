using System;
using System.Collections.Generic;
using System.Text;

namespace sokolenko05DN
{
    public class StudentContainerProcessing
    {
        public delegate double Del(StudentContainer studentArray);

        public static double CalculateAverageAge(StudentContainer studentArray)
        {
            double sum = 0;

            foreach (var student in studentArray.Students)
            {
                sum += student.Age;
            }

            return sum / studentArray.Students.Length;
        }

        public static double CalculateAverageAcademicPerformance(StudentContainer studentArray)
        {
            double sum = 0;

            foreach (var student in studentArray.Students)
            {
                sum += student.Performance;
            }

            return sum / studentArray.Students.Length;
        }

    }
}
