using System;
using System.IO;
using System.Globalization;
using System.Xml.Serialization;

namespace sokolenko06DN
{
    class FilesIO
    {
        private static readonly string DefaultFilename = @"db.txt";
        public static void WriteList(StudentContainer students, string fileName)
        {
            if (fileName == null)
                fileName = DefaultFilename;

            var file = new StreamWriter(fileName, false);
            foreach (Student student in students)
            {
                file.WriteLine(student.LastName);
                file.WriteLine(student.FirstName);
                file.WriteLine(student.Patronymic);
                file.WriteLine(student.BirthDate.ToString("dd MM yyyy"));
                file.WriteLine(student.EnterDate.ToString("dd MM yyyy"));
                file.WriteLine(student.GroupIndex);
                file.WriteLine(student.Faculty);
                file.WriteLine(student.Specialization);
                file.WriteLine(student.Performance);
                file.WriteLine();
            }
            file.Close();
        }

        public static StudentContainer ReadList(string fileName)
        {
            try
            {
                if (fileName == null) 
                    fileName = DefaultFilename;

                var file = new StreamReader(fileName);
                var students = new StudentContainer();
                string line;
                int i = 1;
                while ((line = file.ReadLine()) != null)
                {
                    var student = new Student(line, file.ReadLine(), file.ReadLine(),
                        DateTime.ParseExact(file.ReadLine(), "dd MM yyyy", CultureInfo.InvariantCulture), 
                        DateTime.ParseExact(file.ReadLine(), "dd MM yyyy", CultureInfo.InvariantCulture), 
                        file.ReadLine(), file.ReadLine(), file.ReadLine(), Convert.ToInt32(file.ReadLine()));         
                    line = file.ReadLine();
                    if (line.Equals("")) Console.WriteLine(i++ + " students read");
                    students.AddStudent(student);
                };

                file.Close();

                return students;

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while reading file: " + e.Message);
            }

            return new StudentContainer();
        }

        public static void SaveCollectionInXML(StudentContainer studentArray, string filename)
        {
            XmlSerializer x = new XmlSerializer(studentArray.Students.GetType());
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, studentArray.Students);
            writer.Close();
        }


        public static StudentContainer LoadCollectionFromXML(string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            using FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            Student[] newpeople = (Student[])formatter.Deserialize(fs);
            Student[] arr = new Student[newpeople.Length];

            var studentArray = new StudentContainer
            {
                Students = newpeople,
                Empty = newpeople.Length == 0

            };

            studentArray.RecalculateValues();
            return studentArray;
        }
    }
}
