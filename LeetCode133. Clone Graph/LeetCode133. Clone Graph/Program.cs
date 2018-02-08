using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode133.Clone_Graph
{
	class Program
	{
		//https://leetcode.com/problems/clone-graph/description/
		static void Main(string[] args)
		{
		}
		public class UndirectedGraphNode
		{
			public int label;
			public IList<UndirectedGraphNode> neighbors;
			public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
		}

		public class Solution
		{
			public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
			{
				if (node == null) return null;
				var q = new Queue<UndirectedGraphNode>();
				q.Enqueue(node);
				var map = new Dictionary<int, UndirectedGraphNode>();
				var newRoot = new UndirectedGraphNode(node.label);
				map.Add(newRoot.label, newRoot);
				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					var newCurr = map[curr.label];
					foreach (var c in curr.neighbors)
					{
						UndirectedGraphNode newChild;
						if (!map.TryGetValue(c.label, out newChild))
						{
							newChild = new UndirectedGraphNode(c.label);
							map.Add(c.label, newChild);
							q.Enqueue(c);
						}
						newCurr.neighbors.Add(newChild);
					}
				}
				return newRoot;
			}
		}
	}
}
