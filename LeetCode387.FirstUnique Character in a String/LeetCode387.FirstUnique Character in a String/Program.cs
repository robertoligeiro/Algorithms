using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode387.FirstUnique_Character_in_a_String
{
	class Program
	{
		//https://leetcode.com/problems/first-unique-character-in-a-string/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public int FirstUniqChar(string s)
			{
				var m = new Dictionary<char, int>();
				foreach (var c in s)
				{
					var count = 0;
					if (m.TryGetValue(c, out count))
					{
						m[c] = ++count;
					}
					else m.Add(c, 1);
				}
				for(int i = 0; i < s.Length; ++i)
				{
					if (m[s[i]] == 1) return i;
				}
				return -1;
			}
		}
	}
}
