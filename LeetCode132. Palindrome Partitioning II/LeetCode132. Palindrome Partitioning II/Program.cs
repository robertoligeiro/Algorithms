using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode132.Palindrome_Partitioning_II
{
    class Program
    {
        //https://leetcode.com/problems/palindrome-partitioning-ii/description/
        //time exceed, but works, DP is too complicated, I'm happy with this solution. :)
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.MinCut("aabc");
            r = s.MinCut("fifgbeajcacehiicccfecbfhhgfiiecdcjjffbghdidbhbdbfbfjccgbbdcjheccfbhafehieabbdfeigbiaggchaeghaijfbjhi");
        }
        public class Solution
        {
            public int MinCut(string s)
            {
                return MinCut(s, 0);
            }
            private int MinCut(string s, int countCut)
            {
                if (string.IsNullOrEmpty(s) || IsPalindrome(s, 0, s.Length - 1)) return countCut;
                var min = int.MaxValue;
                for (int i = 0; i < s.Length; ++i)
                {
                    if (IsPalindrome(s, 0, i))
                    {
                        var localMin = MinCut(s.Substring(i + 1), countCut + 1);
                        min = Math.Min(localMin, min);
                    }
                }
                return min;
            }

            private bool IsPalindrome(string s, int l, int r)
            {
                while (l < r)
                {
                    if (s[l] != s[r]) return false;
                    l++;r--;
                }
                return true;
            }
        }
    }
}
