using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace sokolenko05DN
{
    public class StudentContainer : IEnumerable<Student>, IEnumerator<Student>
    {
        public Student[] Students;
        private int _index = -1;
        public bool Empty { get; set; } = true;

        public StudentContainer()
        {
            Students = new Student[0];
        }

        public void AddStudent(Student newStudent)
        {
            Student[] tmpStudentArray = new Student[Students.Length + 1];

            for(int i = 0; i < Students.Length; i++)
            {
                tmpStudentArray[i] = Students[i];
            }

            tmpStudentArray[Students.Length] = newStudent;

            Students = tmpStudentArray;
        }

        public void DeleteStudent(int index)
        {
            Student[] tmpStudentArray = new Student[Students.Length - 1];

            for (int i = 0; i < index; i++)
            {
                tmpStudentArray[i] = Students[i];
            }

            for (int i = index; i < Students.Length - 1; i++)
            {
                tmpStudentArray[i] = Students[i + 1];
            }

            Students = tmpStudentArray;
        }

        public void DeleteStudents(StudentContainer removing)
        {
            for (int i = 0; i < removing.Students.Length; i++)
            {
                for (int j = 0; j < Students.Length; j++)
                {
                    if (this.Students[j].Equals(removing.Students[i]))
                    {
                        DeleteStudent(j);
                    }
                }
            }
        }

        public void ShowByIndex(int index)
        {
            if (index >= Students.Length || index < 0)
            {
                return;
            }

            Io.OutputStudent(Students[index]);
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
                    Students[index].LastName = Io.InputName(); 
                    break;
                case '2':
                    Console.Write("First name: ");
                    Students[index].FirstName = Io.InputName();
                    break;
                case '3':
                    Console.Write("Patronymic: ");
                    Students[index].Patronymic = Io.InputName();
                    break;
                case '4':
                    Console.Write("BirthDay: ");
                    day = Io.InputInt();
                    Console.Write("BirthMonth: ");
                    month = Io.InputInt();
                    Console.Write("BirthYear: ");
                    year = Io.InputInt();
                    Students[index].BirthDate = new DateTime(year, month, day);
                    break;
                case '5':
                    Console.Write("EnterDay: ");
                    day = Io.InputInt();
                    Console.Write("EnterMonth: ");
                    month = Io.InputInt();
                    Console.Write("EnterYear: ");
                    year = Io.InputInt();
                    Students[index].EnterDate = new DateTime(year, month, day);
                    break;
                case '6':
                    Console.Write("Group index: ");
                    Students[index].GroupIndex = Io.InputChar();
                    break;
                case '7':
                    Console.Write("Faculty: ");
                    Students[index].Faculty = Io.InputName();
                    break;
                case '8':
                    Console.Write("Specialization: ");
                    Students[index].Specialization = Io.InputName();
                    break;
                case '9':
                    Console.Write("Performance: ");
                    Students[index].Performance = Io.InputDouble();
                    break;
            }
        }

        public static StudentContainer Search(String criteria, StudentContainer studentArray, int category)
        {
            var searched = new StudentContainer();
            string groupIndex;
            if (studentArray.Students != null)
            {
                switch (category)
                {
                    case 0:
                        {
                            foreach (Student student in studentArray.Students)
                            {
                                if (student.GroupIndex.ToString().ToLower().Contains(criteria.ToLower()))
                                {
                                    searched.AddStudent(student);
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            foreach (Student student in studentArray.Students)
                            {
                                if (student.Faculty.ToLower().Contains(criteria.ToLower()))
                                {
                                    searched.AddStudent(student);
                                }
                            }

                            break;
                        }
                    case 2:
                        {
                            foreach (Student student in studentArray.Students)
                            {
                                if (student.Specialization.ToLower().Contains(criteria.ToLower()))
                                {
                                    searched.AddStudent(student);
                                }
                            }

                            break;
                        }
                }
                return searched;
            }
            return new StudentContainer();
        }

        public void RecalculateValues()
        {

            for (int i = 0; i < Students.Length; i++)
            {
                Students[i] = Student.CopyFrom(Students[i]);
            }

        }

        public IEnumerator<Student> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_index == Students.Length - 1)
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
                return Students[_index];
            }
        }

        object IEnumerator.Current => Students[_index];

        public int Size()
        {
            return Students.Length;
        }
    }

}
