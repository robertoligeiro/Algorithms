using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode139.Word_Break
{
	//https://leetcode.com/problems/word-break/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.WordBreak("aaaaaaa", new List<string>() { "aaaa", "aaa" });
			//var r = s.WordBreak("leetcode", new List<string>() { "leet", "code", "cod", "lee" });
			//var r = s.WordBreak("aaaaaaaa", new List<string>() { "aaa", "aa", "a" });
			//var r = s.WordBreak("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 
			//	new List<string>() { "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa", "ba" });
			//var r = s.WordBreak("ccacccbcab",
			//	new List<string>() { "cc", "bb", "aa", "bc", "ac", "ca", "ba", "cb" });
		}

		public class TrieNode
		{
			public TrieNode[] children = new TrieNode[26];
			public bool isEnd;
		}

		public class Trie
		{
			public TrieNode root = new TrieNode();
			public HashSet<char> foundChars;
			public void AddWord(string w)
			{
				var curr = this.root;
				foreach (var c in w)
				{
					foundChars.Remove(c);
					if (curr.children[c - 'a'] == null)
					{
						curr.children[c - 'a'] = new TrieNode();
					}
					curr = curr.children[c - 'a'];
				}
				curr.isEnd = true;
			}
		}
		public class Solution
		{
			public Trie trie = new Trie();
			public IList<string> words;
			public bool WordBreak(string s, IList<string> wordDict)
			{
				var len = 0;
				var h = new HashSet<char>(s.ToArray());
				trie.foundChars = h;
				foreach (var w in wordDict)
				{
					len += w.Length;
					this.trie.AddWord(w);
				}

				if (h.Count != 0) return false;
				words = wordDict;
				return IsWordBreak(s, 0);
			}

			public bool IsWordBreak(string s, int index)
			{
				if (index == s.Length) return true;
				var curr = this.trie.root;

				int same = index + 1;
				for (; same < s.Length; ++same)
				{
					if (s[same] != s[same-1]) break;
				}
				if (same > index + 1)
				{
					var w = s.Substring(index, same - index);
					foreach (var ss in this.words)
					{
						if (w.Contains(ss) && w.Length % ss.Length == 0)
						{
							if (w.Length == s.Length || same == s.Length) return true;
							index = same;
							break;
						}
					}
				}

				for (int i = index; i < s.Length; ++i)
				{
					var next = curr.children[s[i] - 'a'];
					if ( next == null) return false;
					if (next.isEnd)
					{
						if (IsWordBreak(s, i + 1)) return true;
					}
					curr = next;
				}
				return false;
			}
		}
	}
}
