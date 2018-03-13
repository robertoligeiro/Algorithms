using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCardMatching
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			//var r = s.isMatch("aaaaac", "a*c");
			var r = s.isMatch("aa", "*");
		}

		class Solution
		{
			public bool isMatch(string s, string p)
			{
				int slen = s.Length, plen = p.Length;
				var iS = 0;
				var iP = 0;
				int sStar = -1, pStar = -1;

				for (iS = 0, iP = 0; iS < slen; ++iS, ++iP)
				{
					if (iP >= p.Length) { iP = plen; }
					if (iP < p.Length && p[iP] == '*')
					{ //meet a new '*', update traceback i/j info
						sStar = iS;
						pStar = iP;
						--iS;
					}
					else
					{
						if (iP < p.Length && p[iP] != s[iS] && p[iP] != '?')
						{  // mismatch happens
							if (sStar >= 0)
							{ // met a '*' before, then do traceback
								iS = sStar++;
								iP = pStar;
							}
							else return false; // otherwise fail
						}
					}
				}
				while (iP < p.Length && p[iP] == '*') ++iP;
				return iP >= plen;
			}
		};
	}
}
