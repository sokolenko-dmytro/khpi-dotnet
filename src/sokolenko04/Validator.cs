using System;
using System.Text.RegularExpressions;
using System.Text;

namespace sokolenko04DN
{
    public class Validator
    {
        public static string _namePattern = @"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$";
        public static string _wordsPattern = @"\b[^\d\W]+\b";

        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name.Trim(), _namePattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidateString(string value)
        {
            return Regex.IsMatch(value.Trim(), _wordsPattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidateInt(int min, int max, int value)
        {
            return value >= min && value <= max;
        }
    }
}
