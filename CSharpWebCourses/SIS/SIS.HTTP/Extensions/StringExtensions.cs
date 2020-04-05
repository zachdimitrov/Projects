using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(this string text) => char.ToUpper(text[0]) + text.Substring(1).ToLower();

        public static string DictionaryToString(Dictionary<string, ISet<string>> dictionary)
        {
            string dictionaryString = "";
            foreach (KeyValuePair<string, ISet<string>> keyValues in dictionary)
            {
                dictionaryString += keyValues.Key + ": " + string.Join("; ", keyValues.Value) + "\n\r";
            }
            return dictionaryString.TrimEnd(',', ' ');
        }
    }
}
