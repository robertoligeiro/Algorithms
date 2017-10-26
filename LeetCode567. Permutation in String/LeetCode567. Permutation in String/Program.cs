using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode567.Permutation_in_String
{
	class Program
	{
		//https://leetcode.com/problems/permutation-in-string/description/
		//solution based on #5 here: https://leetcode.com/problems/permutation-in-string/solution/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.CheckInclusion("adc", "dcda");
		}

		public class Solution
		{
			public bool CheckInclusion(string s1, string s2)
			{
				if (s1.Length > s2.Length) return false;
				var histSmaller = new Dictionary<char, int>();
				var histBigger = new Dictionary<char, int>();
				for(int i = 0; i < s1.Length; ++i)
				{
					var count = 0;
					if (histSmaller.TryGetValue(s1[i], out count))
					{
						histSmaller[s1[i]] = ++count;
					}
					else histSmaller.Add(s1[i], 1);

					if (histBigger.TryGetValue(s2[i], out count))
					{
						histBigger[s2[i]] = ++count;
					}
					else histBigger.Add(s2[i], 1);
				}
				if (CheckHists(histSmaller, histBigger)) return true;
				var index = 0;
				for (int i = s1.Length; i < s2.Length; ++i)
				{
					//add new char
					var count = 0;
					if (histBigger.TryGetValue(s2[i], out count))
					{
						histBigger[s2[i]] = ++count;
					}
					else histBigger.Add(s2[i], 1);

					//remove trailing
					if (--histBigger[s2[index]] == 0) histBigger.Remove(s2[index]);
					index++;
					if (CheckHists(histSmaller, histBigger)) return true;
				}
				return false;
			}

			private bool CheckHists(Dictionary<char, int> histSmaller, Dictionary<char, int> histBigger)
			{
				foreach (var t in histSmaller)
				{
					if (!histBigger.ContainsKey(t.Key)) return false;
					if (histBigger[t.Key] != t.Value) return false;
				}
				return true;
			}
		}
	}
}
