using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode212.Word_Search_II
{
    class Program
    {
        //https://leetcode.com/problems/word-search-ii/description/
        static void Main(string[] args)
        {
			//var s = new Solution1();
			//var b = new char[,]
			//{
			//  {'o','a','a','n'},
			//  {'e','t','a','e'},
			//  {'i','h','k','r'},
			//  {'i','f','l','v'}
			//};
			//var r = s.FindWords(b, new string[] { "oath", "pea", "eat", "rain" });
			//var b = new char[,] { { 'a', 'b' }, { 'c', 'd' } };
			//var r = s.FindWords(b, new string[] { "ab", "cb", "ad", "bd", "ac", "ca", "da", "bc", "db", "adcb", "dabc", "abb", "acb" });

			//var b = new char[,] { { 'a' } };
			//var r = s.FindWords(b, new string[] { "a" });
			var s = new Solution();
			var b = new char[,]
			{
			  {'a','b'},
			  {'a','a'},
			};
			var r = s.FindWords(b, new string[] { "aba", "baa", "bab", "aaab", "aaa", "aaaa", "aaba" });
		}

		public class TrieNode
		{
			public bool isEnd = false;
			public Dictionary<char, TrieNode> map = new Dictionary<char, TrieNode>();
		}

		public class Trie
		{
			private TrieNode root = new TrieNode();

			public void AddWord(string w)
			{
				var curr = this.root;
				foreach (var c in w)
				{
					TrieNode next;
					if (!curr.map.TryGetValue(c, out next))
					{
						next = new TrieNode();
						curr.map.Add(c, next);
					}
					curr = next;
				}
				curr.isEnd = true;
			}

			public bool HasPrefix(List<char> parc, ref bool isEnd)
			{
				var curr = this.root;
				foreach (var c in parc)
				{
					TrieNode next;
					if (!curr.map.TryGetValue(c, out next)) return false;
					curr = next;
				}
				isEnd = curr.isEnd;
				return true;
			}
		}
		public class Solution
		{
			private Trie trie = new Trie();
			public IList<string> FindWords(char[,] board, string[] words)
			{
				var m = new Dictionary<char, int>();
				var hWords = new HashSet<string>();
				
				foreach (var w in words)
				{
					hWords.Add(w);
					trie.AddWord(w);
					var size = 0;
					if (m.TryGetValue(w[0], out size))
					{
						m[w[0]] = Math.Max(size, w.Length);
					}
					else
					{
						m.Add(w[0], w.Length);
					}
				}

				var resp = new HashSet<string>();
				for (int row = 0; row < board.GetLength(0); ++row)
				{
					for (int col = 0; col < board.GetLength(1); ++col)
					{
						if (m.ContainsKey(board[row, col]))
						{
							var p = new Tuple<int, int>(row, col);
							var v = new HashSet<Tuple<int, int>>() { p };
							FindWord(board, hWords, p, v, m[board[row, col]], new List<char>() { board[row, col] }, resp);
						}
					}
				}

				return resp.ToList();
			}

			private void FindWord(char[,] board, HashSet<string> words, Tuple<int, int> pos, HashSet<Tuple<int, int>> visited, int maxSize, List<char> parc, HashSet<string> found)
			{
				var isEnd = false;
				if (parc.Count > maxSize || !this.trie.HasPrefix(parc, ref isEnd)) return;
				if (isEnd)
				{
					found.Add(new string(parc.ToArray()));
				}
				var adj = GetAdj(board, pos);
				foreach (var a in adj)
				{
					if (visited.Add(a))
					{
						parc.Add(board[a.Item1, a.Item2]);
						FindWord(board, words, a, visited, maxSize, parc, found);
						parc.RemoveAt(parc.Count - 1);
						visited.Remove(a);
					}
				}
			}

			private List<Tuple<int, int>> GetAdj(char[,] board, Tuple<int, int> pos)
			{
				var up = pos.Item1 - 1;
				var down = pos.Item1 + 1;
				var left = pos.Item2 - 1;
				var right = pos.Item2 + 1;
				var resp = new List<Tuple<int, int>>();
				if (up >= 0) resp.Add(new Tuple<int, int>(up, pos.Item2));
				if (down < board.GetLength(0)) resp.Add(new Tuple<int, int>(down, pos.Item2));
				if (left >= 0) resp.Add(new Tuple<int, int>(pos.Item1, left));
				if (right < board.GetLength(1)) resp.Add(new Tuple<int, int>(pos.Item1, right));
				return resp;
			}
		}
    }
}
