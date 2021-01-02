using System;

namespace sokolenko04DN
{
    public static class Menu
    {
        public static void Start()
        {
            const string path = @"C:\Users\Дмитрий Соколенко\source\repos\DotNet\sokolenko03DN\file.txt";
            var pigsty = new StudentContainer();
            char choice = 'a';

            Console.WriteLine("Hello World! Our copany introduces the next level of data base - AllBase");
            Console.WriteLine("The array of Student object is created, my lord.");

            Io.ReadStContainerFromFile(path, pigsty);

            while (choice != '0')
            {
                PrintMenu();
                Console.Write("Make a choice: ");
                choice = Io.InputChar();

                switch (choice)
                {
                    case '1':
                        Io.ShowAll(pigsty);
                        break;
                    case '2':
                        pigsty.AddStudent(Io.InputStudent());
                        break;
                    case '3':
                        if (pigsty.Size() > 0)
                        {
                            Console.Write("Input the index: ");
                            pigsty.DeleteStudent(Io.InputInt());
                        }
                        else
                        {
                            Console.Write("Container is empty");
                        }
                        break;
                    case '4':
                        if (pigsty.Size() > 0)
                        {
                            Console.Write("Input the index: ");
                            pigsty.ShowByIndex(Io.InputInt());
                        }
                        else
                        {
                            Console.Write("Container is empty");
                        }
                        break;
                    case '5':
                        if (pigsty.Size() > 0)
                        {
                            Console.Write("Input the index: ");
                            pigsty.EditByIndex(Io.InputInt());
                        }
                        else
                        {
                            Console.Write("Container is empty");
                        }
                        break;
                }
            }

            Io.WriteStContainerToFile(path, pigsty);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Choose what you want to do:\n");
            Console.WriteLine("1 - Show data for all students");
            Console.WriteLine("2 - Add new student");
            Console.WriteLine("3 - Delete student by index");
            Console.WriteLine("4 - Show by index");
            Console.WriteLine("5 - Edit the student");
            Console.WriteLine("6 - Show group's info by index");
            Console.WriteLine("\n0 - Exit");
        }
    }
}

