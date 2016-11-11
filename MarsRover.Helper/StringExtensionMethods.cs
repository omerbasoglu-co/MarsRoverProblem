using System.Text.RegularExpressions;

namespace MarsRover.Helper
{
    public static class StringExtensionMethods
    {
        public static string ClearMultipleSpace(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Trim();
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);
                return regex.Replace(text, " ");
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
