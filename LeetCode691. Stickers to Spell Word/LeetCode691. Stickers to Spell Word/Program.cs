using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode691.Stickers_to_Spell_Word
{
	//https://leetcode.com/problems/stickers-to-spell-word/description/
	//not working
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.MinStickers(new string[] { "with", "example", "science"}, "thehat");
		}
		public class Solution
		{
			public int MinStickers(string[] stickers, string target)
			{
				var hist = new Dictionary<char, HashSet<int>>();
				var word = new HashSet<char>(target.ToArray());
				for (int i = 0; i < stickers.Length; ++i)
				{
					foreach (var c in stickers[i])
					{
						if (!word.Contains(c)) continue;
						HashSet<int> h;
						if (hist.TryGetValue(c, out h))
						{
							h.Add(i);
						}
						else hist.Add(c, new HashSet<int>() { i });
					}
				}
				var listIds = new Dictionary<int, HashSet<char>>();
				foreach (var t in hist)
				{
					foreach (var i in t.Value)
					{
						HashSet<char> h;
						if (listIds.TryGetValue(i, out h))
						{
							h.Add(t.Key);
						}
						else listIds.Add(i, new HashSet<char>() { t.Key });
					}
				}

				var lists = listIds.Values.ToList();
				lists = lists.OrderBy(x => x.Count).ToList();
				var toDelete = new int[lists.Count];
				for (int i = 0; i < lists.Count - 1; ++i)
				{
					for (int j = i+1; j < lists.Count; ++j)
					{
						foreach (var c in lists[i])
						{
							if (lists[j].Contains(c))
							{
								toDelete[i]++;
								toDelete[j]++;
							}
						}
					}
				}
				var usedStickers = stickers.Length;
				for (int i = 0; i < toDelete.Length; ++i)
				{
					if (toDelete[i] == lists[i].Count) usedStickers--;
				}
				return usedStickers;
			}
		}
	}
}
