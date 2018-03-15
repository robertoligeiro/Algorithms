using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWords
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = Reverse("The Blue Sky");
		}

		public static string Reverse(string s)
		{
			var sArray = s.ToArray();
			var start = 0;
			var end = 0;
			Array.Reverse(sArray);
			while (end < s.Length)
			{
				while (end < s.Length && s[end] != ' ')
				{
					end++;
				}
				Array.Reverse(sArray, start, end - start);
				end++;
				start = end;
			}
			return new string(sArray);
		}
	}
}
