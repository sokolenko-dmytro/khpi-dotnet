using sokolenko08DN.Services;
using System;
using System.Xml.Serialization;

namespace sokolenko08DN.Models
{
    [Serializable]
    [XmlRoot("student")]
    public class Student
    {
        public long Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime EnterDate { get; set; }
        public string GroupIndex { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public int AcademicPerformance { get; set; }
        public int Age { get; }
        public string Group { get; }
        public string CourseAndSemester { get; }


        public Student() { }

        public Student(long id, string surname, string name, string patronymic, DateTime dob, DateTime enterDate, string groupIndex, string faculty, string specialty, int academicPerformance)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dob;
            EnterDate = enterDate;
            GroupIndex = groupIndex;
            Faculty = faculty;
            Specialty = specialty;
            AcademicPerformance = academicPerformance;
            Age = StudentOperations.GetStudentAge(DateOfBirth);
            Group = StudentOperations.GetStudentGroup(Faculty, GroupIndex);
            CourseAndSemester = StudentOperations.GetCourseAndSemester(EnterDate);
        }

        public static Student CopyFrom(Student student)
        {
            return new Student(student.Id,student.Surname, student.Name, student.Patronymic, student.DateOfBirth, student.EnterDate, student.GroupIndex, student.Faculty, student.Specialty, student.AcademicPerformance);
        }

        public override string ToString()
        {
            return $"Id: {Id}\nSurname: {Surname}\nName: {Name}\nPatronymic: {Patronymic}\nDate of birth: {DateOfBirth}\nEnter date: {EnterDate}\nGroup index: {GroupIndex}\nFaculty: {Faculty}\nSpecialty: {Specialty}\n" +
                $"Academic performance: {AcademicPerformance} \nAge: {Age} \nGroup: {Group} \nStudy progress: {CourseAndSemester} \n";
        }

        public override bool Equals(object obj)
        {
            Student another = (Student)obj;
            return Surname.ToLower().Equals(another.Surname.ToLower()) &&
                Name.ToLower().Equals(another.Name.ToLower()) &&
                Patronymic.ToLower().Equals(another.Patronymic.ToLower()) &&
                DateOfBirth.Equals(another.DateOfBirth) &&
                EnterDate.Equals(another.EnterDate) &&
                GroupIndex.ToLower().Equals(another.GroupIndex.ToLower()) &&
                Faculty.ToLower().Equals(another.Faculty.ToLower()) &&
                Specialty.ToLower().Equals(another.Specialty.ToLower()) &&
                AcademicPerformance == another.AcademicPerformance;
        }
    }
}
