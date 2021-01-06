using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace sokolenko08DN.Models
{

    public class StudentArray : IEnumerable<Student>
    {
        public Student[] Students { get; set; }

        public bool Empty { get; set; } = true;

        public void AddStudent(Student student)
        {
            if (Students == null)
            {
                Students = new Student[0];
            }
            var newArr = new Student[Students.Length + 1];
            for (int i = 0, length = Students.Length; i < length; i++)
            {
                newArr[i] = Students[i];
            }
            newArr[Students.Length] = student;
            Students = newArr;
            if (Empty && Students.Length > 0) Empty = false;

        }

        public void RecalculateValues()
        {

            for(int i = 0; i < Students.Length; i++)
            {
                Students[i] = Student.CopyFrom(Students[i]);
            }

        }

        public Student GetById(long id)
        {
            var studs = from s in Students where s.Id == id select s;
            return studs.First();
        }

        public Student RemoveById(long id)
        {
            for(int i = 0; i < Students.Length; i++)
            {
                if(Students[i].Id == id)
                {
                    var stud = Students[i];
                    DeleteStudentByIndex(i);
                    return stud;
                }
            }

            return null;
        }

        public void Add(object o)
        {
           AddStudent(o as Student); 
                                                 
        }

        public void AddAll(Student[] studs)
        {
            foreach(var stud in studs)
            {
                AddStudent(stud);
            }
        }

        public void DeleteStudentByIndex(int index)
        {
            if (Students != null)
            {
                if (CheckIndex(index))
                {
                    var newArr = new Student[Students.Length - 1];
                    for (int i = 0; i < index; i++)
                    {
                        newArr[i] = Students[i];
                    }

                    for (int i = index + 1, length = Students.Length; i < length; i++)
                    {
                        newArr[i-1] = Students[i];
                    }

                    Students = newArr;
                    if (!Empty && Students.Length == 0) Empty = true;

                }
                else
                {
                    Console.WriteLine("Index out of range");
                }
            }
            else
            {
                Console.WriteLine("Array is empty");
            }
        }

        public void Clear()
        {
            Students = new Student[0];
            Empty = true;
        }

        public Student GetStudent(int index)
        {
            return Students[index];
        }

        public void SetStudent(int index, Student student)
        {
            Students[index] = student;
        }

        private bool CheckIndex(int index)
        {
            return index >= 0 && index <= Students.Length - 1;
        }

        public void Sort()
        {
            Student temp;

            for (int write = 0; write < Students.Length; write++)
            {
                for (int sort = 0; sort < Students.Length - 1; sort++)
                {
                    if (String.Compare(Students[sort].Surname, Students[sort + 1].Surname) > 0)
                    {
                        temp = Students[sort + 1];
                        Students[sort + 1] = Students[sort];
                        Students[sort] = temp;
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            if (Students != null)
            {
                for (int index = 0; index < Students.Length; index++)
                {
                    yield return Students[index];
                }
            }
        }

        IEnumerator<Student> IEnumerable<Student>.GetEnumerator()
        {
            if (Students != null)
            {
                for (int index = 0; index < Students.Length; index++)
                {
                    yield return Students[index];
                }
            }
        }
    }
}
