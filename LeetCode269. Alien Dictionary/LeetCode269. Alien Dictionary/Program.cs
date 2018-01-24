using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode269.Alien_Dictionary
{
	class Program
	{
		//https://leetcode.com/problems/alien-dictionary/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.AlienOrder(new string[] { "wrt", "wrf", "er", "ett", "rftt" });
		}
		public class Solution
		{
			public string AlienOrder(string[] words)
			{
				var chars = new HashSet<char>();
				var charsL = new List<char>();
				var preds = new Dictionary<char, HashSet<char>>();
				var succs = new Dictionary<char, HashSet<char>>();

				var prev = string.Empty;
				foreach (var curr in words)
				{
					foreach (var c in curr)
					{
						if(chars.Add(c)) charsL.Add(c);
					}
					var len = Math.Min(prev.Length, curr.Length);
					for (int i = 0; i < len; ++i)
					{
						if (prev[i] != curr[i])
						{
							HashSet<char> h;
							if (succs.TryGetValue(prev[i], out h))
							{
								h.Add(curr[i]);
							}
							else succs.Add(prev[i], new HashSet<char>() { curr[i]});

							h = null;
							if (preds.TryGetValue(curr[i], out h))
							{
								h.Add(prev[i]);
							}
							else preds.Add(curr[i], new HashSet<char>() { prev[i] });
							break;
						}
					}
					prev = curr;
				}

				var roots = new LinkedList<char>();
				foreach (var c in charsL)
				{
					if (!preds.ContainsKey(c)) roots.AddLast(c);
				}

				var resp = new StringBuilder();
				while (roots.Count > 0)
				{
					var curr = roots.First();
					roots.RemoveFirst();
					resp.Append(curr);
					if (!succs.ContainsKey(curr)) continue;
					foreach (var child in succs[curr])
					{
						preds[child].Remove(curr);
						if (preds[child].Count==0)
						{
							roots.AddFirst(child);
						}
					}
				}

				if (resp.Length == charsL.Count) return resp.ToString();
				return string.Empty;
			}
		}
	}
}
