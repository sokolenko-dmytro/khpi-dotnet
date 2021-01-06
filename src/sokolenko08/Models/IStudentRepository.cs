using System.Collections.Generic;

namespace sokolenko08DN.Models
{
    public interface IStudentRepository
    {
        void Add(Student item);
        IEnumerable<Student> GetAll();
        Student Find(long id);
        Student Remove(long id);
    }
}
