using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode65.Valid_Number
{
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public bool IsNumber(string s)
			{
				if (string.IsNullOrWhiteSpace(s)) return false;
				s = s.Trim();
				bool pointSeen = false;
				bool eSeen = false;
				bool numberSeen = false;
				bool numberAfterE = true;
				var i = 0;
				foreach(var c in s)
				{
					if (char.IsNumber(c))
					{
						numberSeen = true;
						numberAfterE = true;
					}
					else if (c == '.')
					{
						if (eSeen || pointSeen)
						{
							return false;
						}
						pointSeen = true;
					}
					else if (c == 'e')
					{
						if (eSeen || !numberSeen)
						{
							return false;
						}
						numberAfterE = false;
						eSeen = true;
					}
					else if (c == '-' || c == '+')
					{
						if (i != 0 && s[i-1] != 'e')
						{
							return false;
						}
					}
					else
					{
						return false;
					}
					++i;
				}

				return numberSeen && numberAfterE;
			}
		}
	}
}
