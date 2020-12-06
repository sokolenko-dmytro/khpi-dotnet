using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace sokolenko03DN
{
    public class StudentContainer : IEnumerable<Student>, IEnumerator<Student>
    {
        private Student[] _students;
        private int _index = -1;

        public StudentContainer()
        {
            _students = new Student[0];
        }

        public void AddStudent(Student newStudent)
        {
            Student[] tmpStudentArray = new Student[_students.Length + 1];

            for(int i = 0; i < _students.Length; i++)
            {
                tmpStudentArray[i] = _students[i];
            }

            tmpStudentArray[_students.Length] = newStudent;

            _students = tmpStudentArray;
        }

        public void DeleteStudent(int index)
        {
            Student[] tmpStudentArray = new Student[_students.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tmpStudentArray[i] = _students[i];
            }

            for (int i = index; i < _students.Length - 1; i++)
            {
                tmpStudentArray[i] = _students[i + 1];
            }

            _students = tmpStudentArray;
        }

        public void ShowByIndex(int index)
        {
            if (index >= _students.Length || index < 0)
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

        public IEnumerator<Student> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_index == _students.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public void Dispose()
        {
            Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public Student Current
        {
            get
            {
                return _students[_index];
            }
        }

        object IEnumerator.Current => _students[_index];
    }

}
