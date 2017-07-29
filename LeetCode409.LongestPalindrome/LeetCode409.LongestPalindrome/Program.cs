using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode409.LongestPalindrome
{
    //https://leetcode.com/problems/longest-palindrome/description/
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LongestPalindrome("abccccdd");
        }
        public class Solution
        {
            public int LongestPalindrome(string s)
            {
                if (string.IsNullOrEmpty(s)) return 0;
                var h = new HashSet<char>();
                var countPairs = 0;
                foreach (var c in s)
                {
                    if (!h.Add(c))
                    {
                        h.Remove(c);
                        countPairs++;
                    }
                }

                if (h.Count == 0) return countPairs * 2;
                return (countPairs * 2) + 1;
            }
        }
    }
}
