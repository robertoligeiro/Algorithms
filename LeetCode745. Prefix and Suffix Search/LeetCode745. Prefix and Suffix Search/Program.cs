using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode745.Prefix_and_Suffix_Search
{
	class Program
	{
		//https://leetcode.com/problems/prefix-and-suffix-search/description/
		static void Main(string[] args)
		{
			//var wf = new WordFilter(new string[] { "apple", "apprfke", "apeeeprfke" });
			//var w = wf.F("a", "e");
			var wf = new WordFilter(new string[] { "pop"});
			var w = wf.F("p", "pop");

		}

		public class WordFilter
		{
			public class TrieNode
			{
				public TrieNode[] children = new TrieNode[27];
				public int weight;
			}

			public class Trie
			{
				public TrieNode root = new TrieNode();
				public void AddWord(string w, int weight)
				{
					var curr = this.root;
					foreach (var c in w)
					{
						if (curr.children[c - 'a'] == null)
						{
							curr.children[c - 'a'] = new TrieNode();
						}
						curr = curr.children[c - 'a'];
						curr.weight = weight;
					}
					curr.weight = weight;
				}

				public int GetWeight(string prefix, string sufix)
				{
					var t = GetPartial(sufix+"{"+prefix, this.root);
					if (t != null) return t.weight;
					return -1;
				}

				public TrieNode GetPartial(string p, TrieNode curr)
				{
					if (string.IsNullOrEmpty(p)) return curr;
					foreach (var c in p)
					{
						if (curr.children[c - 'a'] == null) return null;
						curr = curr.children[c - 'a'];
					}
					return curr;
				}
			}
			public Trie root = new Trie();
			public WordFilter(string[] words)
			{
				for (int i = 0; i < words.Length; ++i)
				{
					var sufPrefWord = words[i] + "{" + words[i];
					for (int j = 0; j <= words[i].Length; ++j)
					{
						root.AddWord(sufPrefWord.Substring(j), i);
					}
				}
			}

			public int F(string prefix, string suffix)
			{
				return root.GetWeight(prefix, suffix);
			}
		}
	}
}
