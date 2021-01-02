using System;
using System.IO;

namespace sokolenko05DN
{
    public static class Io
    {
        public static Student InputStudent()
        {
            Console.Write("Last name: ");
            string newLastName = InputName();

            Console.Write("First name: ");
            string newFirstName = InputName();

            Console.Write("Patronymic: ");
            string newPatronymic = InputName();

            int day;
            int month;
            int year;
            Console.Write("BirthDay: ");
            day = InputInt();
            Console.Write("BirthMonth: ");
            month = InputInt();
            Console.Write("BirthYear: ");
            year = InputInt();
            DateTime newBirthDate = new DateTime(year, month, day);

            Console.Write("EnterDay: ");
            day = InputInt();
            Console.Write("EnterMonth: ");
            month = InputInt();
            Console.Write("EnterYear: ");
            year = InputInt();
            DateTime newEnterDate = new DateTime(year, month, day);

            Console.Write("Group index: ");
            char newGroupIndex = InputChar();

            Console.Write("Faculty: ");
            string newFaculty = InputString();

            Console.Write("Specialization: ");
            string newSpecialization = InputString();

            Console.Write("Performance: ");
            double newPerformance = InputDouble();

            return new Student(newLastName, 
            newFirstName,
            newPatronymic,
            newBirthDate,
            newEnterDate,
            newGroupIndex,
            newFaculty,
            newSpecialization,
            newPerformance);
        }

        public static void OutputStudent(Student printedStudent)
        {
            Console.WriteLine(printedStudent);
        }

        public static string InputName()
        {
            string name = Console.ReadLine();
            while (!Validator.ValidateName(name))
            {
                Console.WriteLine("Incorrect name.");
                name = Console.ReadLine();
            }
            return name;
        }

        public static int InputInt()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static double InputDouble()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static char InputChar()
        {
            while (true)
            {
                try
                {
                    return Convert.ToChar(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static string InputString()
        {
            string sentence = Console.ReadLine();
            while (!Validator.ValidateString(sentence))
            {
                Console.WriteLine("Incorrect string");
                sentence = Console.ReadLine();
            }
            return sentence;
        }

        public static void ShowContainer(StudentContainer students)
        {
            if (students != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|  №  |     Surname     |      Name       |    Patronymic    |  Date of birth  |  Enter date  |  Group index  |            Faculty            |          Specialty        |    Academic performance   |");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                int i = 0;
                foreach (Student student in students)
                {
                    String output = String.Format("| {0,-3} | {1,-15} | {2,-15} | {3,-16} | {4,-15} | {5,-12} | {6,-13} | {7,-29} | {8,-25} | {9,-25} |",
                        (i++), student.LastName, student.FirstName, student.Patronymic, student.BirthDate.ToString("dd.MM.yyyy"), student.EnterDate.ToString("dd.MM.yyyy"), student.GroupIndex, student.Faculty, student.Specialization, student.Performance);
                    Console.WriteLine(output);
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("Array is empty");
            }

        }

        public static void WriteStContainerToFile(string path, StudentContainer writtenContainer)
        {

            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {

                    foreach (var i in writtenContainer)
                    {
                        sw.WriteLine(i.ToInfoString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void ReadStContainerFromFile(string path, StudentContainer readContainer)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var infoStudent = line.Split(new char[] { '|' });

                        readContainer.AddStudent(new Student(infoStudent[0],
                            infoStudent[1],
                            infoStudent[2],
                            DateTime.Parse(infoStudent[3]),
                            DateTime.Parse(infoStudent[4]),
                            char.Parse(infoStudent[5]),
                            infoStudent[6],
                            infoStudent[7],
                            double.Parse(infoStudent[8])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void PrintPropertyList()
        {
            Console.WriteLine("Choose what you want to edit:\n");
            Console.WriteLine("1 - Last name");
            Console.WriteLine("2 - First name");
            Console.WriteLine("3 - Patronymic");
            Console.WriteLine("4 - Birth date");
            Console.WriteLine("5 - Enter date");
            Console.WriteLine("6 - Group index");
            Console.WriteLine("7 - Faculty");
            Console.WriteLine("8 - Specialization");
            Console.WriteLine("9 - Performance");   
        }

    }
}
