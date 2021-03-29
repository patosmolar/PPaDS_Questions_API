using System.Linq;

namespace PPDS.Core.Extensions
{
    public static class StringExtenstion
    {

        public  static bool IsFirstPlusOrMinus(this string line)
        {
            return (IsFirstMinus(line) || IsFirstPlus(line));
        }
        public static bool IsFirstPlus(this string line)
        {
            return (line.FirstOrDefault(c => !char.IsWhiteSpace(c)) == '+');
        }
        public static bool IsFirstMinus(this string line)
        {
            return (line.FirstOrDefault(c => !char.IsWhiteSpace(c)) == '-');
        }
        public static bool IsFirstSquareBracket(this string line)
        {
            return (line.FirstOrDefault(c => !char.IsWhiteSpace(c)) == '[');
        }
        public static int GetNumberAfterSquareBracket(this string line)
        {

            var tmp = line.Substring(1).FirstOrDefault(c => !char.IsWhiteSpace(c));
            return (int)char.GetNumericValue(tmp);
            
        }
    }
}
