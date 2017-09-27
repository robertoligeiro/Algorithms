using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode516.Longest_Palindromic_Subsequence
{
    class Program
    {
        //https://leetcode.com/problems/longest-palindromic-subsequence/description/
        //not passing.
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LongestPalindromeSubseq("abbac");
        }
        public class Solution
        {
            public int LongestPalindromeSubseq(string s)
            {
                var max = 0;
                for (int i = 0; i < s.Length; ++i)
                {
                    var odd = GetLongest(s, i, i);
                    var even = GetLongest(s, i, i + 1);
                    var localMax = Math.Max(odd, even);
                    max = Math.Max(localMax, max);
                }
                return max;
            }

            private int GetLongest(string s, int i, int j)
            {
                int l;
                int r;
                for (l = i, r = j; l >= 0 && r < s.Length; --l, ++r)
                {
                    if (s[l] != s[r]) break;
                }
                return r - l - 1;
            }
        }
    }
}
