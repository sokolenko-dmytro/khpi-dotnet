using System;

namespace sokolenko02DN
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

            return new Student(newLastName, //todo var
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

        public static void ShowAll(StudentContainer printedContainer)
        {
            foreach (var i in printedContainer)
            {
                OutputStudent(i);
            }
        }
            

    }
}
