using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode383.Ransom_Note
{
	class Program
	{
		//https://leetcode.com/problems/ransom-note/description/
		static void Main(string[] args)
		{
		}

		public class Solution
		{
			public bool CanConstruct(string ransomNote, string magazine)
			{
				var hist = new Dictionary<char, int>();
				foreach (var c in magazine)
				{
					var count = 0;
					if (hist.TryGetValue(c, out count))
					{
						hist[c] = ++count;
					}
					else hist.Add(c, 1);
				}

				foreach (var c in ransomNote)
				{
					var count = 0;
					if (hist.TryGetValue(c, out count))
					{
						if (--count == 0)
						{
							hist.Remove(c);
						}
						else hist[c] = count;
					}
					else return false;
				}
				return true;
			}
		}
	}
}
