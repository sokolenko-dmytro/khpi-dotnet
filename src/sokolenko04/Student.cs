using System;
using System.Collections.Generic;
using System.Text;

namespace sokolenko04DN
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnterDate { get; set; }
        public char GroupIndex { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public double Performance { get; set; }
        public int Age { get; }
        public string GroupInfo { get; }
        public string CourseAndSemester { get; }

        public Student()
        {
            LastName = "Sokolenko";
            FirstName = "Dmitry";
            Patronymic = "Grigorovich";
            BirthDate = new DateTime(2001, 9, 6);
            EnterDate = new DateTime(2018, 9, 1);
            GroupIndex = 'а';
            Faculty = "CIT";
            Specialization = "Computer engeneering";
            Performance = 100.0;
            Age = GetStudentAge();
            GroupInfo = getGroupInfo();
            CourseAndSemester = getCourseAndSemestr();
        }
        public Student(string newLastName, 
            string newFirstName, 
            string newPatronymic,
            DateTime newBirthDate, 
            DateTime newEnterDate,
            char newGroupIndex,
            string newFaculty,
            string newSpecialization,
            double newPerformance)
        {
            LastName = newLastName;
            FirstName = newFirstName;
            Patronymic = newPatronymic;
            BirthDate = newBirthDate;
            EnterDate = newEnterDate;
            GroupIndex = newGroupIndex;
            Faculty = newFaculty;
            Specialization = newSpecialization;
            Performance = newPerformance;
        }

        public override string ToString()
        {
            return $"Last name: {LastName}\nFirst name: {FirstName}\n" +
                $"Patronymic: {Patronymic}\nBirthDate: {BirthDate.ToString("d")}\n" +
                $"EnterDate: {EnterDate.ToString("d")}\nGroup Index: {GroupIndex}\n" +
                $"Faculty: {Faculty}\nSpecialization: {Specialization}\nPerformance: {Performance}\n" +
                $"Age: {Age}\nGroup information: {GroupInfo}\nSemester and course: {CourseAndSemester}\n";
        }

        private int GetStudentAge()
        {
            var today = DateTime.Today;

            int diff;
            if (today.CompareTo(BirthDate) > 0)
            {
                diff = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-diff)) 
                    diff--;
                return diff;
            }
            else
            {
                diff = BirthDate.Year - today.Year;
                if (today.Date > BirthDate.AddYears(-diff)) 
                    diff--;
                return diff;
            }
        }

        public string ToInfoString()
        {
            return $"{LastName}|{FirstName}|{Patronymic}|{BirthDate.ToString("d")}|" +
                $"{EnterDate.ToString("d")}|{GroupIndex}|{Faculty}|{Specialization}|{Performance}";
        }

        private string getGroupInfo()
        {

            var info = new StringBuilder();
            info.Append($"{this.Faculty} - {this.Specialization} - {this.EnterDate.Year} - {this.GroupIndex}\n");

            return info.ToString();
        }

        private string getCourseAndSemestr()
        {
            int semester;

            var nowDate = DateTime.Now;
            int course;

            if (nowDate.Month >= 8)
            {
                course = nowDate.Year - this.EnterDate.Year + 1;
            }
            else
            {
                course = nowDate.Year - this.EnterDate.Year;
            }

            if (nowDate.Month >= 8)
            {
                semester = course * 2 - 1;
            }
            else
            {
                semester = course * 2;
            }

            var info = new StringBuilder();
            info.Append($"Name: {this.LastName} {this.FirstName} {this.Patronymic}\n" +
                $"Course: {course}, Semester: {semester}\n");

            return info.ToString();
        }


    }
}
