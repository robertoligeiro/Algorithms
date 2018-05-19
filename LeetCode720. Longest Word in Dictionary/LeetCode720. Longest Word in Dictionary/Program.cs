using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode720.Longest_Word_in_Dictionary
{
	//https://leetcode.com/problems/longest-word-in-dictionary/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.LongestWord(new string[] { "a", "banana", "app", "appl", "ap", "apply", "apple" });
			//var r = s.LongestWord(new string[] { "d", "do", "dog", "p", "pe", "pen", "peng", "pengu", "pengui", "penguin", "e", "el", "ele", "elep", "eleph", "elepha", "elephan", "elephant"});
		}

		public class Solution
		{
			public class TrieNode
			{
				public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
				public int end;
			}

			public class Trie
			{
				private TrieNode root = new TrieNode();
				private string[] words;
				public Trie(string[] words)
				{
					this.words = words;
				}
				public void Insert(string w, int index)
				{
					var curr = this.root;
					foreach (var c in w)
					{
						TrieNode next = null;
						if (!curr.children.TryGetValue(c, out next))
						{
							next = new TrieNode();
							curr.children.Add(c, next);
						}
						curr = next;
					}
					curr.end = index;
				}

				public string Dfs()
				{
					var resp = string.Empty;
					var s = new Stack<TrieNode>();
					s.Push(root);

					while (s.Count > 0)
					{
						var curr = s.Pop();
						if (curr.end > 0 || curr == this.root)
						{
							if (curr != this.root)
							{
								var candidate = this.words[curr.end - 1];
								if (candidate.Length > resp.Length || (candidate.Length == resp.Length && candidate.CompareTo(resp) < 0))
								{
									resp = candidate;
								}
							}

							foreach (var c in curr.children.Values)
							{
								s.Push(c);
							}
						}
					}
					return resp;
				}
			}
			public string LongestWord(string[] words)
			{
				var trie = new Trie(words);
				var index = 0;
				foreach (var w in words)
				{
					trie.Insert(w, ++index);
				}
				return trie.Dfs();
			}
		}
	}
}
