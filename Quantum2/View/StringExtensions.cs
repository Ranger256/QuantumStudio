using System;
using System.Collections.Generic;

namespace Quantum2
{
    public static class StringExtensions
    {
        public static string[] SplitKeepSeparators(this string s, params char[] separators)
        {
            if (s == null) throw new ArgumentNullException("s");
            if (s.Length == 0) return new string[] { s };

            var hash = new HashSet<char>(separators);
            var list = new List<string>();

            int i = 0;
            for (int j = 0; j < s.Length; j++)
            {
                if (hash.Contains(s[j]))
                {
                    list.Add((j > i ? s.Substring(i, j - i) : string.Empty) );
                    list.Add(Convert.ToString(s[j]));
                    i = j + 1;
                }
            }
            if (i == 0) return new string[] { s };

            list.Add(i == s.Length ? string.Empty : s.Substring(i));

            return list.ToArray();
        }

    }
}
