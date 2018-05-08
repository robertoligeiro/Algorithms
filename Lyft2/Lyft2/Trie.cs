using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyft2
{
	internal class TrieNode
	{
		public Dictionary<char, TrieNode> Children { get; set; }
		public Dictionary<string, WordRank> Words { get; set; }
		public bool IsEndWord { get; set; }
		public TrieNode()
		{
			Children = new Dictionary<char, TrieNode>();
			Words = new Dictionary<string, WordRank>();
		}
	}

	public class WordRank
	{
		public int id { get; set; }
		public int frequency { get; set; }
	}
	public class Trie
	{
		private TrieNode root = new TrieNode();

		public void AddWord(string w, int id)
		{
			var curr = this.root;
			foreach (var c in w)
			{
				this.AddWordToLevel(curr, w, id);

				//adding to trie
				TrieNode next = null;
				if (!curr.Children.TryGetValue(c, out next))
				{
					next = new TrieNode();
					curr.Children.Add(c, next);
					curr = next;
				}
				else
				{
					curr = next;
				}
			}

			this.AddWordToLevel(curr, w, id);
			curr.IsEndWord = true;
		}

		public List<Tuple<string, WordRank>> FindWord(string prefix)
		{
			var curr = this.root;
			var resp = new List<Tuple<string, WordRank>>();
			foreach (var c in prefix)
			{
				TrieNode next = null;
				if (!curr.Children.TryGetValue(c, out next))
				{
					return resp;
				}
				curr = next;
			}

			foreach (var t in curr.Words)
			{
				resp.Add(new Tuple<string, WordRank>(t.Key, t.Value));
			}
			return resp;
		}

		private void AddWordToLevel(TrieNode curr, string w, int id)
		{
			WordRank wordsInLevel = null;
			if (!curr.Words.TryGetValue(w, out wordsInLevel))
			{
				curr.Words.Add(w, new WordRank() { id = id, frequency = 1 });
			}
			else
			{
				curr.Words[w].frequency++;
			}
		}
	}
}
