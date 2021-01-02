using System;

namespace sokolenko05DN
{
    public static class Menu
    {
        public static void Start()
        {
            const string path = @"C:\Users\Дмитрий Соколенко\source\repos\DotNet\sokolenko05DN\file.txt";
            const string xmlPath = @"C:\Users\Дмитрий Соколенко\source\repos\DotNet\sokolenko05DN\file.xml";
            var pigsty = new StudentContainer();
            char choice = 'a';
            int intChoice;
            string strChoice = "";


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
                        PrintOptions();
                        Console.WriteLine("3 - All students");
                        Console.Write("Make a choice: ");
                        intChoice = Io.InputInt();

                        if(intChoice != 3)
                        {
                            Console.WriteLine("Enter criteria: ");
                            strChoice = Console.ReadLine();

                            Io.ShowContainer(StudentContainer.Search(strChoice, pigsty, intChoice));
                        }
                        else
                        {
                            Io.ShowContainer(pigsty);
                        }

                        
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
                    case '6':
                        PrintOptions();
                        Console.Write("Make a choice: ");
                        intChoice = Io.InputInt();

                        Console.WriteLine("Enter criteria: ");
                        strChoice = Console.ReadLine();
                        pigsty.DeleteStudents(StudentContainer.Search(strChoice, pigsty, intChoice)); 
                        break;
                    case '7':
                        PrintMathematicOptions();
                        Console.Write("Make a choice: ");
                        intChoice = Io.InputInt();

                        StudentContainerProcessing.Del del = null;
                        switch (intChoice)
                        {
                            case 0:
                                {
                                    del = StudentContainerProcessing.CalculateAverageAge;
                                    break;
                                }
                            case 1:
                                {
                                    del = StudentContainerProcessing.CalculateAverageAcademicPerformance;
                                    break;
                                }
                        }

                        PrintOptions();

                        Console.Write("Make a choice: ");
                        intChoice = Io.InputInt();

                        Console.WriteLine("Enter criteria: ");
                        strChoice = Console.ReadLine();

                        Console.WriteLine(del?.Invoke(StudentContainer.Search(strChoice, pigsty, intChoice)));
                        break;
                    case '8':
                            Serialization.SaveCollectionInXML(pigsty, xmlPath);
                            break;
                    case '9':
                            pigsty = Serialization.LoadCollectionFromXML(xmlPath);
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
            Console.WriteLine("6 - Remove students by any critaria");
            Console.WriteLine("7 - Print some average value");
            Console.WriteLine("8 - Save in XML");
            Console.WriteLine("9 - Load from XML");
            Console.WriteLine("\n0 - Exit");
        }

        private static void PrintOptions()
        {
            Console.WriteLine("Choose: \n");
            Console.WriteLine("0 - By group");
            Console.WriteLine("1 - By faculty");
            Console.WriteLine("2 - By speciality");
        }

        private static void PrintMathematicOptions()
        {
            Console.WriteLine("Choose: \n");
            Console.WriteLine("0 - Print average age");
            Console.WriteLine("1 - Print average academic performance");
        }
    }
}

