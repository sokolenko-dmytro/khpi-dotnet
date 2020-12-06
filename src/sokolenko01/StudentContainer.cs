using System;
using System.Collections.Generic;
using System.Text;

namespace sokolenko01DN
{
    public class StudentContainer
    {
        public int Size { get; set; }
        private Student[] _students;

        public StudentContainer()
        {
            Size = 0;
            _students = new Student[0];
        }

        public void AddStudent(Student newStudent)
        {
            Student[] tmpStudentArray = new Student[Size + 1];//todo var

            for(int i = 0; i < Size; i++)
            {
                tmpStudentArray[i] = _students[i];
            }

            tmpStudentArray[Size] = newStudent;

            _students = tmpStudentArray;
            Size++;
        }

        public void DeleteStudent(int index)
        {
            Student[] tmpStudentArray = new Student[Size - 1];

            for (int i = 0; i < index; i++)
            {
                tmpStudentArray[i] = _students[i];
            }

            for (int i = index; i < Size - 1; i++)
            {
                tmpStudentArray[i] = _students[i + 1];
            }

            _students = tmpStudentArray;
            Size--;
        }

        public void ShowByIndex(int index)
        {
            if (index >= Size || index < 0)
            {
                return;
            }

            Io.OutputStudent(_students[index]);
        }
        public void ShowAll()
        {
            foreach (var i in _students)
            {
                Io.OutputStudent(i);
            }
        }
    }
}
