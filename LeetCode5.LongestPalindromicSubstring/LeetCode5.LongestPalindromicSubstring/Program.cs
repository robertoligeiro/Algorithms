using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode5.LongestPalindromicSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.LongestPalindrome("babad");
        }
        public class Solution
        {
            public string LongestPalindrome(string s)
            {
                if (string.IsNullOrEmpty(s)) return string.Empty;
                var resp = string.Empty;
                for (int i = 0; i < s.Length; ++i)
                {
                    if (IsPalindrome(s, 0, i))
                    {
                        if (i > resp.Length - 1) resp = s.Substring(0, i + 1);
                        if ((s.Length - i + 1) > resp.Length)
                        {
                            var respFromSub = LongestPalindrome(s.Substring(i + 1));
                            if (respFromSub.Length > resp.Length)
                            {
                                resp = respFromSub;
                            }
                        }
                    }
                }
                return resp;
            }

            private bool IsPalindrome(string s, int l, int r)
            {
                while (l < r)
                {
                    if (s[l++] != s[r--]) return false;
                }

                return true;
            }
        }
    }
}
