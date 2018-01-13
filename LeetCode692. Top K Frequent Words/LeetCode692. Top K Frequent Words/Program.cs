using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode692.Top_K_Frequent_Words
{
	//https://leetcode.com/problems/top-k-frequent-words/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.TopKFrequent(new string[] { "i", "love", "leetcode", "love", "i", "coding" }, 2);
		}

		public class Solution
		{
			public IList<string> TopKFrequent(string[] words, int k)
			{
				var map = new Dictionary<string, int>();
				foreach(var w in words)
				{
					var count = 0;
					if (map.TryGetValue(w, out count)) map[w] = ++count;
					else map.Add(w, 1);
				}
				var resp = new List<Tuple<int, string>>();
				foreach(var t in map)
				{
					if (resp.Count < k)
					{
						resp.Add(new Tuple<int, string>(t.Value, t.Key));
						resp.Sort(SortWords);
						continue;
					}

					//if freq is bigger, or if it's same but curr word is lex smaller
					if (t.Value > resp.Last().Item1 || (t.Value == resp.Last().Item1 && t.Key.CompareTo(resp.Last().Item2) < 0))
					{
						resp.RemoveAt(resp.Count - 1);
						resp.Add(new Tuple<int, string>(t.Value, t.Key));
						resp.Sort(SortWords);
					}
				}
				return resp.Select(x => x.Item2).ToList();
			}

			private int SortWords(Tuple<int, string> a, Tuple<int, string> b)
			{
				//a.compareto(b) cause lexo order is in order
				if (b.Item1 == a.Item1) return a.Item2.CompareTo(b.Item2);

				// b.compareto(a) because freq is sorted in reverse order.
				return b.Item1.CompareTo(a.Item1);
			}
		}
	}
}
