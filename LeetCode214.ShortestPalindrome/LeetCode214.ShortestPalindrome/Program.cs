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
			var ss = new SolutionNew();
			var r = s.ShortestPalindrome("aaaba");
			var rr = ss.ShortestPalindrome("aaaba");

			//var r = s.ShortestPalindrome("aacecaaa"); //aaaaacecaaa, aaacecaaa
			//var rr = ss.ShortestPalindrome("aacecaaa"); //aaaaacecaaa, aaacecaaa
		}

		public class SolutionNew
		{
			public string ShortestPalindrome(string s)
			{
				var resp = new StringBuilder();
				var indexS = 0;
				var indexRev = 0;
				var rev = new string(s.Reverse().ToArray());
				while (indexRev < s.Length)
				{
					if (s[indexS] == rev[indexRev])
					{
						resp.Append(rev[indexRev]);
						indexRev++;
						indexS++;
					}
					else
					{
						resp.Append(rev[indexRev]);
						indexRev++;
					}
				}
				resp.Append(s.Substring(indexS));
				return resp.ToString();
			}
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
