using System.Collections.Generic;

namespace LyftTries.DataModel
{
	public interface ITrieNode
	{
		bool IsEndWord { get; set; }
		HashSet<int> GetIndexes();
		void AddIndex(int i);
		ITrieNode[] Children { get; set; }
	}
}
