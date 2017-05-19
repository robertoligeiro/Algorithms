using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsOneEditAway
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = IsOneEditAway("pale", "pall"); // true
            b = IsOneEditAway("pale", "pale"); // true
            b = IsOneEditAway("pal", "pall"); // true
            b = IsOneEditAway("pale", "pabb"); // false
            b = IsOneEditAway("pale", "pab"); // false
        }

        public static bool IsOneEditAway(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1) return false;
            var largerIndex = s1.Length >= s2.Length ? s1 : s2;
            var smallerIndex = s1.Length < s2.Length ? s1 : s2;
            var i = 0;
            var j = 0;
            var diff = 0;
            while (i < largerIndex.Length && j < smallerIndex.Length)
            {
                if (largerIndex[i] != smallerIndex[j])
                {
                    if (++diff > 1) return false;
                    if (largerIndex.Length == smallerIndex.Length) j++;
                }
                else j++;
                i++;
            }

            return true;
        }
    }
}
