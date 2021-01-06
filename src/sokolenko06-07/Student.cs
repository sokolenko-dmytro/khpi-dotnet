using System;
using System.Xml.Serialization;

namespace sokolenko06DN
{
    [Serializable]
    [XmlRoot("student")]
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnterDate { get; set; }
        public string GroupIndex { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public int Performance { get; set; }
        public int Age{ get; }
        public string Group { get; }
        public string CourseAndSemester { get; }


        public Student() { }

        public Student(string surname, string name, string patronymic, DateTime dob, DateTime enterDate, string groupIndex, string faculty, string specialty, int academicPerformance)
        {
            LastName = surname;
            FirstName = name;
            Patronymic = patronymic;
            BirthDate = dob;
            EnterDate = enterDate;
            GroupIndex = groupIndex;
            Faculty = faculty;
            Specialization = specialty;
            Performance = academicPerformance;
            Age = StudentContainerProcessing.GetStudentAge(BirthDate);
            Group = StudentContainerProcessing.GetStudentGroup(Faculty, GroupIndex);
            CourseAndSemester = StudentContainerProcessing.GetCourseAndSemester(EnterDate);
        }

        public static Student CopyFrom(Student student)
        {
            return new Student(student.LastName,student.FirstName, student.Patronymic, student.BirthDate, student.EnterDate, student.GroupIndex, student.Faculty, student.Specialization, student.Performance);
        }

        public override string ToString()
        {
            return $"LastName: {LastName}\nFirstName: {FirstName}\nPatronymic: {Patronymic}\nDate of birth: {BirthDate}\nEnter date: {EnterDate}\nGroup index: {GroupIndex}\nFaculty: {Faculty}\nSpecialty: {Specialization}\n" +
                $"Academic performance: {Performance} \nAge: {Age} \nGroup: {Group} \nStudy progress: {CourseAndSemester} \n";
        }

        public override bool Equals(object obj)
        {
            Student another = (Student)obj;
            return LastName.ToLower().Equals(another.LastName.ToLower()) &&
                FirstName.ToLower().Equals(another.FirstName.ToLower()) &&
                Patronymic.ToLower().Equals(another.Patronymic.ToLower()) &&
                BirthDate.Equals(another.BirthDate) &&
                EnterDate.Equals(another.EnterDate) &&
                GroupIndex.ToLower().Equals(another.GroupIndex.ToLower()) &&
                Faculty.ToLower().Equals(another.Faculty.ToLower()) &&
                Specialization.ToLower().Equals(another.Specialization.ToLower()) &&
                Performance == another.Performance;
        }
    }
}
