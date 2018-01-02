using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
	class Program
	{
		static void Main(string[] args)
		{
			var t = new Trie();
			t.insert("house");
			var b = t.search("house");
			b = t.search("hous");
			b = t.search("housee");
		}

		public class TrieNode
		{
			public TrieNode[] children = new TrieNode[26]; 
			public bool isEnd;
		}

		public class Trie
		{
			private TrieNode root = new TrieNode();
			public void insert(string s)
			{
				var curr = this.root;
				foreach (var c in s)
				{
					if (curr.children[c - 'a'] == null) curr.children[c - 'a'] = new TrieNode();
					curr = curr.children[c - 'a'];
				}
				curr.isEnd = true;
			}

			public bool search(string s)
			{
				var curr = this.root;
				foreach (var c in s)
				{
					if (curr.children[c - 'a'] == null) return false;
					curr = curr.children[c - 'a'];
				}
				return curr.isEnd;
			}
		}
	}
}
