using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode5.LongestPalindromicSubstring
{
    class Program
    {
        //https://leetcode.com/problems/longest-palindromic-substring/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.LongestPalindrome("babad");
            var r = s.LongestPalindrome("babadaaaaaaabaaaaaaadafg");
        }

        public class Solution
        {
            private int lo, maxLen;

            public string LongestPalindrome(string s)
            {
                int len = s.Length;
                if (len < 2)
                    return s;

                for (int i = 0; i < len - 1; i++)
                {
                    extendPalindrome(s, i, i);  //assume odd length, try to extend Palindrome as possible
                    extendPalindrome(s, i, i + 1); //assume even length.
                }
                return s.Substring(lo,maxLen);
            }

            private void extendPalindrome(string s, int j, int k)
            {
                while (j >= 0 && k < s.Length && s[j] == s[k])
                {
                    j--;
                    k++;
                }
                if (maxLen < k - j - 1)
                {
                    lo = j + 1;
                    maxLen = k - j - 1;
                }
            }
        }
    }
}
