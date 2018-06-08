using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/sentence-similarity-ii/description/
namespace LeetCode737.Sentence_Similarity_II
{
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var b = s.AreSentencesSimilarTwo(
				new string[] { "great", "acting", "skills" },
				new string[] { "fine", "drama", "talent" },
				new string[,] { { "great", "good" }, { "fine", "good" }, { "acting", "drama" }, { "skills", "talent" } });

			//var words1 = new string[] { "I", "have", "enjoyed", "happy", "thanksgiving", "holidays" };
			//var words2 = new string[] { "I", "have", "enjoyed", "happy", "thanksgiving", "holidays" };
			//var pairs = new string[,] {
			//	{ "great","good"},
			//		{ "extraordinary","good"},
			//		{ "well","good"},
			//		{ "wonderful","good"},
			//		{ "excellent","good"},
			//		{ "fine","good"},
			//		{ "nice","good"},
			//		{ "any","one"},
			//		{ "some","one"},
			//		{ "unique","one"},
			//		{ "the","one"},
			//		{ "an","one"},
			//		{ "single","one"},
			//		{ "a","one"},
			//		{ "truck","car"},
			//		{ "wagon","car"},
			//		{ "automobile","car"},
			//		{ "auto","car"},
			//		{ "vehicle","car"},
			//		{ "entertain","have"},
			//		{ "drink","have"},
			//		{ "eat","have"},
			//		{ "take","have"},
			//		{"fruits","meal"},
			//		{ "brunch","meal"},{
			//		"breakfast","meal"},{
			//		"food","meal"},{
			//		"dinner","meal"},{
			//		"super","meal"},{
			//		"lunch","meal"},{
			//		"possess","own"},{
			//		"keep","own"},{
			//		"have","own"},{
			//		"extremely","very"},{
			//		"actually","very"},{
			//		"really","very"},{
			//		"super","very"}
			//};

			//var b = s.AreSentencesSimilarTwo(words1, words2, pairs);
		}

		public class Solution
		{
			public class Node
			{
				public string word;
				public List<Node> children = new List<Node>();
			}
			public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[,] pairs)
			{
				if (words1.Length != words2.Length) return false;
				var m = new Dictionary<string, Node>();
				GetTrees(pairs, m);

				for (int i = 0; i < words1.Length; ++i)
				{
					var w1 = words1[i];
					var w2 = words2[i];

					var found = false;
					var s = new Stack<string>();
					var visited = new HashSet<string>();
					s.Push(w1);
					visited.Add(w1);
					while (s.Count > 0)
					{
						var curr = s.Pop();
						if (curr == w2)
						{
							found = true;
							break;
						}

						Node n = null;
						if (!m.TryGetValue(curr, out n)) return false;

						foreach (var c in n.children)
						{
							if (visited.Add(c.word)) s.Push(c.word);
						}
					}
					if (!found) return false;
				}

				return true;
			}

			public void GetTrees(string[,] pairs, Dictionary<string, Node> m)
			{
				for (int i = 0; i < pairs.GetLength(0); ++i)
				{
					Node n1 = null;
					if (!m.TryGetValue(pairs[i, 0], out n1))
					{
						n1 = new Node() { word = pairs[i, 0] };
						m.Add(n1.word, n1);
					}
					Node n2 = null;
					if (!m.TryGetValue(pairs[i, 1], out n2))
					{
						n2 = new Node() { word = pairs[i, 1] };
						m.Add(n2.word, n2);
					}

					n1.children.Add(n2);
					n2.children.Add(n1);
				}
			}
		}
		//public class Solution
		//{
		//	public class Node
		//	{
		//		public string word;
		//		public List<Node> children = new List<Node>();
		//	}
		//	public bool AreSentencesSimilarTwo(string[] words1, string[] words2, string[,] pairs)
		//	{
		//		if (words1.Length != words2.Length) return false;
		//		var m = new Dictionary<string, Node>();
		//		GetTrees(pairs, m);

		//		var w1 = new HashSet<string>(words1);
		//		var w2 = new HashSet<string>(words2);
		//		var removed = new HashSet<string>();
		//		var found = new HashSet<string>();
		//		foreach (var w in words1)
		//		{
		//			Node n = null;
		//			if (found.Contains(w)) continue;
		//			if (w2.Contains(w))
		//			{
		//				removed.Add(w);
		//				continue;
		//			}
		//			if (!removed.Add(w)) continue;
		//			if (!m.TryGetValue(w, out n)) return false;
		//			var visited = new HashSet<string>();
		//			if(!DoDfs(n, null, n.word, visited, w2, found)) return false;
		//			found.Add(n.word);
		//		}
		//		foreach (var w in words2)
		//		{
		//			Node n = null;
		//			if (found.Contains(w)) continue;
		//			if (w1.Contains(w))
		//			{
		//				removed.Add(w);
		//				continue;
		//			}
		//			if (!removed.Add(w)) continue;
		//			if (!m.TryGetValue(w, out n)) return false;
		//			var visited = new HashSet<string>();
		//			if (!DoDfs(n, null, n.word, visited, w1, found)) return false;
		//			found.Add(n.word);
		//		}

		//		return true;
		//	}

		//	public bool DoDfs(Node n, Node parent, string rootWord, HashSet<string> visited, HashSet<string> w, HashSet<string> found)
		//	{
		//		if (!visited.Add(n.word)) return false;
		//		foreach (var c in n.children)
		//		{
		//			if (c != parent)
		//			{
		//				if (w.Contains(c.word))
		//				{
		//					found.Add(c.word);
		//					return true;
		//				}
		//				else
		//					if (DoDfs(c, n, rootWord, visited, w, found)) return true;
		//			}
		//		}
		//		return false;
		//	} 
		//	public void GetTrees(string[,] pairs, Dictionary<string, Node> m)
		//	{
		//		for (int i = 0; i < pairs.GetLength(0); ++i)
		//		{
		//			Node n1 = null;
		//			if (!m.TryGetValue(pairs[i, 0], out n1))
		//			{
		//				n1 = new Node() { word = pairs[i, 0] };
		//				m.Add(n1.word, n1);
		//			}
		//			Node n2 = null;
		//			if (!m.TryGetValue(pairs[i, 1], out n2))
		//			{
		//				n2 = new Node() { word = pairs[i, 1] };
		//				m.Add(n2.word, n2);
		//			}

		//			n1.children.Add(n2);
		//			n2.children.Add(n1);
		//		}
		//	}
		//}
	}
}
