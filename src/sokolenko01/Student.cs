using System;
using System.Collections.Generic;
using System.Text;

namespace sokolenko01DN
{
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; } // todo 
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnterDate { get; set; }
        public char GroupIndex { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public double Performance { get; set; }

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
                $"Faculty: {Faculty}\nSpecialization: {Specialization}\nPerformance: {Performance}\n";
        }

    }
}
