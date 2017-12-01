using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode472.Concatenated_Words
{
	//https://leetcode.com/submissions/detail/130324879/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class TrieNode
		{
			public TrieNode[] children = new TrieNode[26];
			public bool IsEndWord;
		}

		public class Trie
		{
			public TrieNode root = new TrieNode();

			public void AddWord(string w)
			{
				var curr = this.root;
				foreach (var c in w)
				{
					if (curr.children[c - 'a'] == null)
					{
						curr.children[c - 'a'] = new TrieNode();
					}
					curr = curr.children[c - 'a'];
				}
				curr.IsEndWord = true;
			}
		}

		public class Solution
		{
			public Trie trie = new Trie();
			public IList<string> FindAllConcatenatedWordsInADict(string[] words)
			{
				foreach (var w in words)
				{
					if (string.IsNullOrEmpty(w)) continue;
					trie.AddWord(w);
				}
				var resp = new List<string>();
				foreach (var w in words)
				{
					if (string.IsNullOrEmpty(w)) continue;
					if (IsConcat(w, 0, 0))
					{
						resp.Add(w);
					}
				}
				return resp;
			}

			private bool IsConcat(string w, int index, int countWords)
			{
				if (countWords >= 2 && index == w.Length) return true;
				var curr = this.trie.root;
				for (int i = index; i < w.Length; ++i)
				{
					if (curr.children[w[i] - 'a'] == null) return false;
					curr = curr.children[w[i] - 'a'];
					if (curr.IsEndWord)
					{
						if (IsConcat(w, i + 1, countWords + 1)) return true;
					}
				}
				return false;
			}
		}
	}
}
