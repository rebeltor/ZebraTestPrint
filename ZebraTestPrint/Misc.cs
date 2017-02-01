using System;
using System.Collections.Generic;
using System.Text;

namespace ZebraTestPrint
{
    public class Misc
    {
        /// <summary>
        /// Returns true if a and b are either both null, or neither is null
        /// </summary>        
        public static bool EqualNullality(object a, object b)
        {
            return EqualNullality<object>(a, b);
        }
        /// <summary>
        /// Returns true if a and b are either both null, or neither is null
        /// </summary>        
        public static bool EqualNullality<T>(T a, T b)
        {
            return ((a == null) && (b == null)) || ((a != null) && (b != null));
        }

        public static bool NullSafeEquals(object a, object b)
        {
            return EqualNullality(a, b) &&
                ((a == null) || (a.Equals(b)));
        }

        public static bool NullSafeEquals<T>(T a, T b)
        {
            return EqualNullality<T>(a, b) &&
                ((a == null) || (a.Equals(b)));
        }

        /// <summary>
        /// Removes all instances of the characters in the given array from the given string
        /// </summary>
        /// <param name="source">the source string</param>
        /// <param name="c">the characters to remove from source</param>
        /// <returns>the source string, with the given characters removed</returns>
        public static string StripChars(string source, char[] chars)
        {
            StringBuilder sb = new StringBuilder(source.Length);
            foreach (char c in source.ToCharArray())
            {
                if (!ArrayEx.Exists<char>(chars, c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}