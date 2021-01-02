using System.IO;
using System.Xml.Serialization;

namespace sokolenko05DN
{
    public class Serialization
    {

        public static void SaveCollectionInXML(StudentContainer studentContainer, string filename)
        {
            XmlSerializer x = new XmlSerializer(studentContainer.Students.GetType());
            TextWriter writer = new StreamWriter(filename);
            x.Serialize(writer, studentContainer.Students);
            writer.Close();
        }


        public static StudentContainer LoadCollectionFromXML(string filename) {
            XmlSerializer formatter = new XmlSerializer(typeof(Student[]));
            using FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            Student[] newPeople = (Student[])formatter.Deserialize(fs);
            Student[] arr = new Student[newPeople.Length];

            var studentArray = new StudentContainer
            {
                Students = newPeople,
                Empty = newPeople.Length == 0
               
            };

            studentArray.RecalculateValues();
            return studentArray;
        }

    }
}
