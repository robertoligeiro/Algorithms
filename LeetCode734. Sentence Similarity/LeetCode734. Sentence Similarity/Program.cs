using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode734.Sentence_Similarity
{
	class Program
	{
		//https://leetcode.com/problems/sentence-similarity/description/
		static void Main(string[] args)
		{
		}
		public class Solution
		{
			public bool AreSentencesSimilar(string[] words1, string[] words2, string[,] pairs)
			{
				if (words1.Length != words2.Length) return false;
				var map = new Dictionary<string, HashSet<String>>();
				for (int i = 0; i < pairs.GetLength(0); ++i)
				{
					HashSet<string> h;
					if (map.TryGetValue(pairs[i, 0], out h)) h.Add(pairs[i, 1]);
					else map.Add(pairs[i, 0], new HashSet<string>() { pairs[i, 1] });
					if (map.TryGetValue(pairs[i, 1], out h)) h.Add(pairs[i, 0]);
					else map.Add(pairs[i, 1], new HashSet<string>() { pairs[i, 0] });
				}

				for (int i = 0; i < words1.Length; ++i)
				{
					if (words1[i] == words2[i] ||
						(map.ContainsKey(words1[i]) && map[words1[i]].Contains(words2[i])))
					{
						continue;
					}
					else return false;
				}
				return true;
			}
		}
	}
}
