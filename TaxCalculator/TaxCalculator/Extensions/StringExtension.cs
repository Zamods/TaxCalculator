/*
 * https://alexdunn.org
 * Credits : Alex Dunn
 */
using System.Text.RegularExpressions;

namespace TaxCalculator.Extensions
{
    public static class StringExtension
    {
        public static string SplitCamelCaseToEngineDisplacementString(this string str)
        {
            return Regex.Replace(Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\p{Ll}\P{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2"), @"(to)", " $1"); 
        }
    }
}
