using System;

namespace sokolenko01DN
{
    public static class Menu
    {
        public static void Start()
        {
            var pigsty = new StudentContainer();
            char choice = 'a';

            Console.WriteLine("Hello World! Our copany introduces the next level of data base - AllBase");
            Console.WriteLine("The array of Student object is created, my lord.");

            while (choice != '0')
            {
                PrintMenu();
                Console.Write("Make a choice: ");
                choice = Io.InputChar();

                switch (choice)
                {
                    case '1':
                        pigsty.ShowAll();
                        break;
                    case '2':
                        pigsty.AddStudent(Io.InputStudent());
                        break;
                    case '3':
                        Console.Write("Input the index: ");
                        pigsty.DeleteStudent(Io.InputInt());
                        break;
                    case '4':
                        Console.Write("Input the index: ");
                        pigsty.ShowByIndex(Io.InputInt());
                        break;
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("Choose what you want to do:\n");
            Console.WriteLine("1 - Show data for all students");
            Console.WriteLine("2 - Add new student");
            Console.WriteLine("3 - Delete student by index");
            Console.WriteLine("4 - Show by index");
            Console.WriteLine("\n0 - Exit");
        }
    }
}

