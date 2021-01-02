using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace sokolenko04DN
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

        public void EditByIndex(int index)
        {

            int day;
            int month;
            int year;

            char choice = 'a';

            Io.PrintPropertyList();
            choice = Io.InputChar();

            switch (choice)
            {
                case '1':
                    Console.Write("Last name: ");
                    _students[index].LastName = Io.InputName(); 
                    break;
                case '2':
                    Console.Write("First name: ");
                    _students[index].FirstName = Io.InputName();
                    break;
                case '3':
                    Console.Write("Patronymic: ");
                    _students[index].Patronymic = Io.InputName();
                    break;
                case '4':
                    Console.Write("BirthDay: ");
                    day = Io.InputInt();
                    Console.Write("BirthMonth: ");
                    month = Io.InputInt();
                    Console.Write("BirthYear: ");
                    year = Io.InputInt();
                    _students[index].BirthDate = new DateTime(year, month, day);
                    break;
                case '5':
                    Console.Write("EnterDay: ");
                    day = Io.InputInt();
                    Console.Write("EnterMonth: ");
                    month = Io.InputInt();
                    Console.Write("EnterYear: ");
                    year = Io.InputInt();
                    _students[index].EnterDate = new DateTime(year, month, day);
                    break;
                case '6':
                    Console.Write("Group index: ");
                    _students[index].GroupIndex = Io.InputChar();
                    break;
                case '7':
                    Console.Write("Faculty: ");
                    _students[index].Faculty = Io.InputName();
                    break;
                case '8':
                    Console.Write("Specialization: ");
                    _students[index].Specialization = Io.InputName();
                    break;
                case '9':
                    Console.Write("Performance: ");
                    _students[index].Performance = Io.InputDouble();
                    break;
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

        public int Size()
        {
            return _students.Length;
        }
    }

}
