using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode647.Palindromic_Substrings
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CountSubstrings("abc");
        }

        public class Solution
        {
            public int CountSubstrings(string s)
            {
                return CountPalindromes(s, 0);
            }

            private int CountPalindromes(string s, int start)
            {
                if (start == s.Length)
                {
                    return 0;
                }
                var countLocal = 0;
                for (int i = start; i < s.Length; ++i)
                {
                    if (IsPal(s, start, i))
                    {
                        countLocal++;
                    }
                }
                return CountPalindromes(s, start + 1) + countLocal;
            }
            private bool IsPal(string s, int start, int end)
            {
                while (start < end)
                {
                    if (s[start] != s[end]) return false;
                    start++;end--;
                }
                return true;
            }
        }
    }
}
