using sokolenko08DN.Services;
using System.Collections.Generic;

namespace sokolenko08DN.Models
{
    public class StudentRepository : IStudentRepository
    {
        private static StudentArray studs;

        public StudentRepository()
        {
            studs = Serialization.LoadCollectionFromXML("db.xml");
        }

        public IEnumerable<Student> GetAll()
        {
            return studs.Students;
        }

        public void Add(Student item)
        {
            studs.AddStudent(item);
        }

        public Student Find(long id)
        {
            return studs.GetById(id);
        }

        public Student Remove(long id)
        {
            return studs.RemoveById(id);
        }

    }
}
