using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManagementLibrary
{
    public static class Extention
    {
        public static string ToCapitalize(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return value;

            string newStr = Char.ToUpper(value[0]).ToString();
            if (value.Length > 1)
            {
                newStr = newStr + value.Substring(1).ToLower();
            }
            return newStr;
        }
        public static bool IsContainsLetter(this string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!Char.IsLetter(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
