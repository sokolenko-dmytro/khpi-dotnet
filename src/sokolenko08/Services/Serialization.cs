using sokolenko08DN.Models;
using System.IO;
using System.Xml.Serialization;

namespace sokolenko08DN.Services
{
    public class Serialization
    {

        public static void SaveCollectionInXML(StudentArray studentArray, string filename)
        {
            XmlSerializer x = new XmlSerializer(studentArray.Students.GetType());
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, studentArray.Students);
            writer.Close();
        }


        public static StudentArray LoadCollectionFromXML(string filename) {
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            using FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            Student[] newpeople = (Student[])formatter.Deserialize(fs);
            Student[] arr = new Student[newpeople.Length];

            var studentArray = new StudentArray
            {
                Students = newpeople,
                Empty = newpeople.Length == 0
               
            };

            studentArray.RecalculateValues();
            return studentArray;
        }

    }
}
