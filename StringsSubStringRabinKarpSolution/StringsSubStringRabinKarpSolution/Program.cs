using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsSubStringRabinKarpSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindSubstring("abcdefghij", "ig");
        }

        public static int FindSubstring(string s, string t)
        {
            var hTarget = t.GetHashCode();
            for (int i = 0; i < s.Length - t.Length + 1; ++i)
            {
                var curr = s.Substring(i, t.Length);
                if (hTarget == curr.GetHashCode())
                {
                    var isEqual = true;
                    for (int j = 0; j < t.Length; ++j)
                    {
                        if (curr[j] != t[j]) isEqual = false; 
                    }
                    if (isEqual) return i;
                }
            }

            return -1;
        }
    }
}
