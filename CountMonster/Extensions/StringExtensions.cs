using System.Text.RegularExpressions;

namespace CountMonster.Extensions
{
    public static class StringExtensions
    {
        private static Regex NonAlphaNumericRegex = new Regex(@"\W");

        public static string Sanitize(this string input)
        {
            return NonAlphaNumericRegex.Replace(input, string.Empty);
        }

        public static string Slugify(this string input)
        {
            return input.ToLower().Replace(" ", "-").Replace("--", "-");
        }

    }
}
