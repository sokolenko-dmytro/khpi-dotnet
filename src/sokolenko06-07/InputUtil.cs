//using System;
//using System.Globalization;

//namespace sokolenko06DN
//{
//    class InputUtil
//    {
//        private static readonly string ErrorMessage = "Invalid input. Check and try again";

//        public static string EnterName(string fieldName)
//        {
//            Console.WriteLine("Enter " + fieldName + ":");
//            string name = Console.ReadLine();
//            while (!Validator.ValidateName(name))
//            {
//                Console.WriteLine(ErrorMessage);
//                name = Console.ReadLine();
//            }
//            return name;
//        }

//        public static string EnterSentence(string fieldName)
//        {
//            Console.WriteLine("Enter " + fieldName + ":");
//            string sentence = Console.ReadLine();
//            while (!Validator.ValidateSentence(sentence))
//            {
//                Console.WriteLine(ErrorMessage);
//                sentence = Console.ReadLine();
//            }
//            return sentence;
//        }

//        public static string EnterString(string fieldName)
//        {
//            Console.WriteLine("Enter " + fieldName + ":");
//            string str = Console.ReadLine();
//            return str;
//        }

//        public static int EnterPercents(string fieldName)
//        {
//            Console.WriteLine("Enter " + fieldName + ":");
//            while (true)
//            {
//                try
//                {
//                    int value = Convert.ToInt32(Console.ReadLine());
//                    if (Validator.ValidateIntByRange(0, 100, value))
//                    {
//                        return value;
//                    }
//                    continue;
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//        }

//        public static int EnterInt(string fieldName)
//        {
//            Console.WriteLine("Enter " + fieldName + ":");
//            while (true)
//            {
//                try
//                {
//                    int value = Convert.ToInt32(Console.ReadLine());
//                    return value;
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e.Message);
//                }
//            }
//        }

//        public static DateTime EnterDate(String fieldName)
//        {
//            Console.WriteLine("Enter " + fieldName + ":");
//            while (true)
//            {
//                try
//                {
//                    Console.WriteLine("Enter date in format dd MM yyyy");
//                    string date = Console.ReadLine();
//                    return DateTime.ParseExact(date, "dd MM yyyy", CultureInfo.InvariantCulture);
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("An exception occured while date input:" + e.Message);
//                }
//            }
//        }

//    }
//}
