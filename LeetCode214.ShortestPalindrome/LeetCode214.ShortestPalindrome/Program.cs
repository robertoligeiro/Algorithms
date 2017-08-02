using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode214.ShortestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            //var r = s.ShortestPalindrome("aaaba");
            var r = s.ShortestPalindrome("aacecaaa"); //aaaaacecaaa, aaacecaaa
        }

        public class Solution
        {
            public string ShortestPalindrome(string s)
            {
                var sReversed = new string(s.ToCharArray().Reverse().ToArray());
                var n = s.Length;
                int l;
                for (l = n; l >= 0; --l)
                {
                    //s.Substring(0, l) - substring from 0 to l {0-len, 0-len-1, 0-len-2, ...}
                    //sReversed.Substring(n - l) - substring starting at index n-1 {0, 1, 2, 3,...}
                    if (s.Substring(0, l) == sReversed.Substring(n - l)) break;
                    // aacecaaa == aaacecaa -> false
                    // ^      ^    ^      ^
                    // aacecaaa == aaacecaa -> true
                    // ^     ^      ^     ^
                }

                return sReversed.Substring(0, n - l) + s;
            }
        }
    }
}
