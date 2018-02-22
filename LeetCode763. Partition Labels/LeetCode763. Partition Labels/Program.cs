using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode763.Partition_Labels
{
	class Program
	{
		//https://leetcode.com/problems/partition-labels/description/
		static void Main(string[] args)
		{
			var S = "ababcbacadefegdehijhklij";
			var s = new Solution();
			var r = s.PartitionLabels(S);
		}

		public class Solution
		{
			public IList<int> PartitionLabels(string S)
			{
				var hist = new Dictionary<char, int>();
				foreach (var c in S)
				{
					var count = 0;
					if (hist.TryGetValue(c, out count))
					{
						hist[c] = ++count;
					}
					else hist.Add(c, 1);
				}

				var resp = new List<int>();
				var h = new HashSet<char>();
				var lastAdd = 0;
				for (int i = 0; i < S.Length; ++i)
				{
					var count = 0;
					if (hist.TryGetValue(S[i], out count))
					{
						if (--count == 0)
						{
							hist.Remove(S[i]);
							h.Remove(S[i]);
							if (h.Count == 0)
							{
								resp.Add(i-lastAdd+1);
								lastAdd = i + 1;
							}
						}
						else
						{
							h.Add(S[i]);
							hist[S[i]] = count;
						} 
					}
				}
				return resp;
			}
		}
	}
}
