using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode208.Implement_Trie__Prefix_Tree_2
{
	//https://leetcode.com/problems/implement-trie-prefix-tree/description/
	class Program
	{
		static void Main(string[] args)
		{
		}
		public class Trie
		{
			private class TrieNode
			{
				public TrieNode[] children = new TrieNode[26];
				public bool isEnd;
			}

			private TrieNode root = new TrieNode();
			/** Initialize your data structure here. */
			public Trie()
			{

			}

			/** Inserts a word into the trie. */
			public void Insert(string word)
			{
				var curr = this.root;
				foreach (var c in word)
				{
					if (curr.children[c - 'a'] == null)
					{
						curr.children[c - 'a'] = new TrieNode();
					}
					curr = curr.children[c - 'a'];
				}
				curr.isEnd = true;
			}

			/** Returns if the word is in the trie. */
			public bool Search(string word)
			{
				return this.Search(word, true);
			}

			/** Returns if there is any word in the trie that starts with the given prefix. */
			public bool StartsWith(string prefix)
			{
				return this.Search(prefix, false);
			}

			private bool Search(string word, bool checkEnd)
			{
				var curr = this.root;
				foreach (var c in word)
				{
					if (curr.children[c - 'a'] == null) return false;
					curr = curr.children[c - 'a'];
				}
				if (checkEnd) return curr.isEnd;
				return true;
			}
		}
	}
}
