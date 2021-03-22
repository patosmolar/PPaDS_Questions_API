using System.Linq;

namespace PPDS.Core.Extensions
{
    public static class StringExtenstion
    {

        public  static bool IsFirstSpecial(this string line)
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
    }
}
