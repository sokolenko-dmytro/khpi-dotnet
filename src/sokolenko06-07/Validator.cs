using System.Text.RegularExpressions;

namespace sokolenko06DN
{
    class Validator
    {
        private static readonly string NamePattern = @"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$";
        private static readonly string SentencePattern = @"\b[^\d\W]+\b";

        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name.Trim(), NamePattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidateSentence(string sentence)
        {
            return Regex.IsMatch(sentence.Trim(), SentencePattern, RegexOptions.IgnoreCase);
        }

        public static bool ValidateIntByRange(int min, int max, int value)
        {
            return value >= min && value <= max;
        }                                                                                                              


    }
}

