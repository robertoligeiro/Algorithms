using LyftTries.DataModel;
using System.Collections.Generic;

namespace LyftTries
{
	public class Trie
	{
		private ITrieNode root = new TrieNode();
		private Dictionary<int, string> wordIndexs = new Dictionary<int, string>();

		public Trie(IList<string> words)
		{
			for (int i = 0; i < words.Count; ++i)
			{
				this.AddWord(words[i], i);
			}
		}

		public void AddWord(string w, int index)
		{
			var curr = this.root;
			foreach (var c in w)
			{
				if (curr.Children[c - 'a'] == null)
				{
					curr.Children[c - 'a'] = new TrieNode();
				}
				curr.AddIndex(index);
				curr = curr.Children[c - 'a'];
			}
			curr.AddIndex(index);
			curr.IsEndWord = true;
			this.wordIndexs.Add(index, w);
		}

		public IList<string> FindWords(string prefix)
		{
			var curr = this.root;
			var resp = new List<string>();
			foreach (var c in prefix)
			{
				if (curr.Children[c - 'a'] == null) return resp;
				curr = curr.Children[c - 'a'];
			}
			foreach (var i in curr.GetIndexes())
			{
				resp.Add(this.wordIndexs[i]);
			}
			return resp;
		}
	}
}
