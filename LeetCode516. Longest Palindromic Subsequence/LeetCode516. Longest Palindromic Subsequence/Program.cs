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
				var memo = new Dictionary<Tuple<int, int>, int>();
				return GetLongest(s, 0, s.Length - 1, memo);
            }

            private int GetLongest(string s, int l, int r, Dictionary<Tuple<int, int>, int> memo)
            {
				if (l == r) return 1;
				if (l > r) return 0;
				var count = 0;
				var t = new Tuple<int, int>(l, r);
				if (memo.TryGetValue(t, out count)) return count;
				count = s[l] == s[r] 
					? 2 + GetLongest(s, l + 1, r - 1, memo) 
					: Math.Max(GetLongest(s, l + 1, r, memo), GetLongest(s, l, r - 1, memo));
				memo.Add(t, count);
				return count;
            }
        }
    }
}
