using System;
using System.Collections.Generic;

namespace LyftTries.DataModel
{
	public class TrieNode : ITrieNode
	{
		private HashSet<int> indexes = new HashSet<int>();
		public bool IsEndWord { get; set; }

		public ITrieNode[] Children { get; set; }

		public TrieNode()
		{
			Children = new ITrieNode[26];
		}

		public HashSet<int> GetIndexes()
		{
			return this.indexes;
		}

		public void AddIndex(int i)
		{
			this.indexes.Add(i);
		}
	}
}
