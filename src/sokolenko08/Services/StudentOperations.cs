using System;
using System.Text;
using System.Linq;
using sokolenko08DN.Models;

namespace sokolenko08DN.Services
{
    public class StudentOperations
    {
        public delegate double Del(StudentArray studentArray);

        public static double CalculateAverageAge(StudentArray studentArray)
        {
            return (from s in studentArray.Students select s.Age).Average();
        }

        public static double CalculateAverageAcademicPerformance(StudentArray studentArray)
        {
            return (from s in studentArray.Students select s.AcademicPerformance).Average();
        }

        public static string GetStudentGroup(string faculty, string groupIndex)
        {
            var sb = new StringBuilder(AbbreviationFrom(faculty)).Append("-").Append(groupIndex);
            return sb.ToString();
        }

        public static string AbbreviationFrom(string data)
        {
            return string.Join("", data.Where(char.IsUpper));
        }

        public static string GetCourseAndSemester(DateTime enterDate)
        {
            var today = DateTime.Today;
            var years = YearDiff(today, enterDate);
            var course = years;
            int semester;
            if (today.Month > 9 || today.Month == 1)
            {
                course++;
                semester = 1;
            }
            else
            {
                semester = 2;
            }
            var sb = new StringBuilder();
            if (course <= 6)
            {
                sb = new StringBuilder("Course ").Append(course).Append(", semester ").Append(semester);
            }
            else
            {
                sb = new StringBuilder("Graduated");
            }
            return sb.ToString();
        }

        public static int GetStudentAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            if (birthDate.CompareTo(today) > 0) return -1;      
            return YearDiff(today, birthDate);
        }

        public static StudentArray SearchBySurname(String surname,StudentArray studentArray)
        {
            var searched = new StudentArray();
            if (studentArray.Students != null)
            {
                var studs = studentArray.Cast<Student>().Where(s => s.Surname.ToLower().Contains(surname.ToLower())).Select(s => s);
                foreach (var st in studs)
                {
                    searched.Add(st);
                }
                return searched;
            }
            return new StudentArray();
        }

        public static StudentArray Search(String predicate, StudentArray studentArray,int category)
        {
            var searched = new StudentArray();
            if (studentArray.Students != null)
            {
                switch (category) {

                    case 0:
                        {
                            var studs = from s in studentArray.Students where s.Group.ToLower().Contains(predicate.ToLower()) select s; //отложенное выполнение запроса
                            foreach (var st in studs)
                            {
                                searched.Add(st);
                            }
                            break;
                        }

                    case 1:
                        {
                            var studs = (from s in studentArray.Students where s.Specialty.ToLower().Contains(predicate.ToLower()) select s).ToList(); //принудительное выполнение запроса
                            foreach (var st in studs)
                            {
                                searched.Add(st);
                            }

                            break;
                        }
                    case 2:
                        {
                            var studs = studentArray.Cast<Student>().Where(s => s.Faculty.ToLower().Contains(predicate.ToLower())).Select(s => s);//lambda
                            foreach (var st in studs)
                            {
                                searched.Add(st);
                            }

                            break;
                        }

                }        
                return searched;
            }
            return new StudentArray();
        }

        public static StudentArray RemoveStudents(StudentArray studentArray, StudentArray removing)
        {
            for(int i = 0; i < removing.Students.Length; i++)
            {
                for(int j = 0; j < studentArray.Students.Length; j++)
                {
                    if (studentArray.Students[j].Equals(removing.Students[i]))
                    {
                        studentArray.DeleteStudentByIndex(j);
                    }
                }
            }

            return studentArray;
        }

        private static int YearDiff(DateTime firstDate, DateTime secondDate)
        {
            int diff;
            if (firstDate.CompareTo(secondDate) > 0) {
                diff = firstDate.Year - secondDate.Year;
                if (secondDate.Date > firstDate.AddYears(-diff)) diff--;
                return diff;
            }
            else
            {
                diff = secondDate.Year - firstDate.Year;
                if (firstDate.Date > secondDate.AddYears(-diff)) diff--;
                return diff;
            }
        }
    }
}