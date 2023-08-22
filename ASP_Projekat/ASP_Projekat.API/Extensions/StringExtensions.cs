using System.Diagnostics.CodeAnalysis;

namespace ASP_Projekat.API.Extensions
{
    public class StringExtensions
    {
        public static bool NotNullOrEmpty(string str)
        {
            return !string.IsNullOrEmpty(str);
        }
    }
}
