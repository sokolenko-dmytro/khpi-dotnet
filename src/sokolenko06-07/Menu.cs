using System;

namespace sokolenko06DN
{
    class Menu
    {
        public static void Start()
        {
            var pigsty = new StudentContainer();


            const string fileName = @"C:\Users\Дмитрий Соколенко\source\repos\DotNet\sokolenko05DN\file.txt";
            pigsty = FilesIO.ReadList(fileName);

            const string fileNameXml = @"C:\Users\Дмитрий Соколенко\source\repos\DotNet\sokolenko05DN\file.xml";

            while (true)
            {
                PrintMainMenu();
                int choice;
                try
                {
                    choice = Io.EnterInt("choice");
                    switch (choice)
                    {
                        case 1:
                            {
                                PrintStudents();
                                int printChoice = Io.EnterInt("printChoice");
                                switch (printChoice)
                                {
                                    case 0:
                                        {
                                            Io.PrintStudents(pigsty);
                                            break;
                                        }
                                    case 1:
                                        {
                                            Io.PrintStudents(StudentContainerProcessing.Search(Io.EnterString("group"), pigsty, printChoice - 1));
                                            break;
                                        }
                                    case 2:
                                        {
                                            Io.PrintStudents(StudentContainerProcessing.Search(Io.EnterString("specialty"), pigsty, printChoice - 1));
                                            break;
                                        }
                                    case 3:
                                        {
                                            Io.PrintStudents(StudentContainerProcessing.Search(Io.EnterString("faculty"), pigsty, printChoice - 1));
                                            break;
                                        }
                                }

                                break;
                            }
                        case 2:
                            {
                                pigsty.AddStudent(CreateStudent());
                                break;
                            }
                        case 3:
                            {
                                Io.PrintStudents(pigsty);
                                pigsty.DeleteStudentByIndex(Io.EnterInt("index") - 1);
                                break;
                            }
                        case 4:
                            {
                                var index = GetIndex(pigsty);
                                var student = pigsty.GetStudent(index);
                                Console.WriteLine(student.ToString());
                                int edit = Io.EnterInt("1 if you want to edit");
                                if (edit == 1)
                                {
                                    student = CreateStudent();
                                    pigsty.SetStudent(index, student);
                                }
                                break;
                            }
                        case 5:
                            {
                                RemoveStudents();
                                int deleteChoice = Io.EnterInt("deleteChoice");
                                pigsty = StudentContainerProcessing.RemoveStudents(pigsty, StudentContainerProcessing.Search(Io.EnterString("choice"), pigsty, deleteChoice));
                                break;
                            }
                        case 6:
                            {
                                AvgCalculateOperations();
                                int avgOperations = Io.EnterInt("avgChoice"); ;
                                StudentContainerProcessing.Del del = null;
                                switch (avgOperations)
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

                                RemoveStudents();
                                int searchChoice = Io.EnterInt("searchChoice");
                                Console.WriteLine(del?.Invoke(StudentContainerProcessing.Search(Io.EnterString("choice"), pigsty, searchChoice)));
                                break;
                            }
                        case 7:
                            {
                                FilesIO.SaveCollectionInXML(pigsty, fileNameXml);
                                break;
                            }
                        case 8:
                            {
                                pigsty = FilesIO.LoadCollectionFromXML(fileNameXml);
                                break;
                            }
                        case 0:
                            {
                                FilesIO.WriteList(pigsty, fileName);
                                return;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1 - Show students");
            Console.WriteLine("2 - Add new student");
            Console.WriteLine("3 - Delete student by index");
            Console.WriteLine("4 - Show by index (and edit)");
            Console.WriteLine("5 - Remove students by any critaria");
            Console.WriteLine("6 - Print some average value");
            Console.WriteLine("7 - Save in XML");
            Console.WriteLine("8 - Load from XML");
            Console.WriteLine("0 - Exit");
        }

        public static void PrintStudents()
        {
            Console.WriteLine("0 - All students");
            Console.WriteLine("1 - By group");
            Console.WriteLine("2 - By specialty");
            Console.WriteLine("3 - By faculty");
        }

        public static void RemoveStudents()
        {
            Console.WriteLine("0 - By group");
            Console.WriteLine("1 - By specialty");
            Console.WriteLine("2 - By faculty");
        }

        public static void AvgCalculateOperations()
        {
            Console.WriteLine("0 - Average age");
            Console.WriteLine("1 - Average academic performance");
        }

        public static Student CreateStudent()
        {
            var student = new Student(Io.EnterName("LastName"),
                Io.EnterName("FirstName"),
                Io.EnterName("Patronymic"),
                Io.EnterDate("BirthDate"),
                Io.EnterDate("EnterDate"),
                Io.EnterString("GroupIndex"),
                Io.EnterSentence("Faculty"),
                Io.EnterSentence("Specialization"),
                Io.EnterPercents("Performance"));
            return student;
        }

        private static int GetIndex(StudentContainer studentArray)
        {
            Io.PrintStudents(studentArray);
            return Io.EnterInt("index") - 1;
        }

    }
}
