using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode261.Graph_Valid_Tree
{
	class Program
	{
		//https://leetcode.com/problems/graph-valid-tree/description/
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.ValidTree(5, new int[,] { { 0, 1 }, { 0, 2 }, { 2, 3 }, { 2, 4 } });
		}
		public class Solution
		{
			public class Node
			{
				public int id;
				public List<Node> children = new List<Node>();
			}
			public bool ValidTree(int n, int[,] edges)
			{
				if (edges == null || edges.Length == 0) return n == 0;
				var map = new Dictionary<int,Node>();
				for (int i = 0; i < edges.GetLength(0); ++i)
				{
					Node n1 = null;
					if (!map.TryGetValue(edges[i, 0], out n1))
					{
						n1 = new Node() { id = edges[i, 0] };
						map.Add(n1.id, n1);
					}
					Node n2 = null;
					if (!map.TryGetValue(edges[i, 1], out n2))
					{
						n2 = new Node() { id = edges[i, 1] };
						map.Add(n2.id, n2);
					}
					n1.children.Add(n2);
					n2.children.Add(n1);
				}

				var visited = new HashSet<int>();
				if (!HasCycle(map.FirstOrDefault().Value, null, visited)) return false;
				return visited.Count == n;
			}

			private bool HasCycle(Node curr, Node parent, HashSet<int> visited)
			{
				if (!visited.Add(curr.id)) return false;
				foreach (var c in curr.children)
				{
					if (c != parent)
					{
						if (!HasCycle(c, curr, visited)) return false;
					}
				}
				return true;
			}
		}
	}
}
