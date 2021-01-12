using sokolenko08DN.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace sokolenko08DN.Models
{
    public class StudentRepository : IStudentRepository
    {
        private static StudentArray studs;

        public StudentRepository()
        {
            if (!File.Exists("db.xml"))
            {
                studs = new StudentArray();
                Student st = new Student();
                st.AcademicPerformance = 21;

                st.Id = 1;
                st.Surname = "Surname1";
                st.Name = "Name1";
                st.Patronymic = "Patronymic1";
                st.DateOfBirth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddYears(-21);
                st.EnterDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(21);
                st.GroupIndex = "GroupIndex1";
                st.Faculty = "Faculty1";
                st.Specialty = "Specialty1";

                studs.Add(st);
                st = new Student();
                st.AcademicPerformance = 21;

                st.Id = 3;
                st.Surname = "Surname3";
                st.Name = "Name3";
                st.Patronymic = "Patronymic3";
                st.DateOfBirth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddYears(-23);
                st.EnterDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(-23);
                st.GroupIndex = "GroupIndex3";
                st.Faculty = "Faculty3";
                st.Specialty = "Specialty3";

                studs.Add(st);
                st = new Student();
                st.AcademicPerformance = 21;

                st.Id = 5;
                st.Surname = "Surname5";
                st.Name = "Name5";
                st.Patronymic = "Patronymic5";
                st.DateOfBirth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddYears(-25);
                st.EnterDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(378);
                st.GroupIndex = "GroupIndex5";
                st.Faculty = "Faculty5";
                st.Specialty = "Specialty5";

                studs.Add(st);
                Serialization.SaveCollectionInXML(studs, "db.xml");
            }
            studs = Serialization.LoadCollectionFromXML("db.xml");
        }

        public IEnumerable<Student> GetAll()
        {
            return studs.Students;
        }

        public void Add(Student item)
        {
           
            studs.AddStudent(Student.CopyFrom(item));
        }

        public Student Find(long id)
        {
            return studs.GetById(id);
        }

        public Student Remove(long id)
        {
            return studs.RemoveById(id);
        }

        public void Update(Student item)
        {
            int? index = studs.GetIndex(item);
            if (index.HasValue)
                studs.SetStudent(index.Value, Student.CopyFrom(item));
        }

        public void SaveDb()
        {
            studs.RecalculateValues();
            
            Serialization.SaveCollectionInXML(studs, "db.xml"); ;
        }
    }
}
