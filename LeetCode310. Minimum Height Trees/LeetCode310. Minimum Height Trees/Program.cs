using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode310.Minimum_Height_Trees
{
    class Program
    {
        //time exceeding in leet code, have to implement better finder for min h.
        //like from here:
        //https://leetcode.com/problems/minimum-height-trees/discuss/
        static void Main(string[] args)
        {
			var s = new Solution();
			//var r = s.FindMinHeightTrees(6, new int[,] { { 1,0}, { 1,2}, { 1,3} });

			var r = s.FindMinHeightTrees(6, new int[,] { { 0, 3 }, { 1, 3 }, { 2, 3 }, { 4, 3 }, { 5, 4 } });

			//var r = s.FindMinHeightTrees(1, new int[,] {  });
		}

		public class Node
        {
            public int val;
            public List<Node> children = new List<Node>();
        }

		public class Solution
		{
			public IList<int> FindMinHeightTrees(int n, int[,] edges)
			{
				//Build graph
				var map = new Dictionary<int, Node>();
				for (int i = 0; i < edges.GetLength(0); ++i)
				{
					Node n0;
					Node n1;
					if (!map.TryGetValue(edges[i, 0], out n0))
					{
						n0 = new Node() { val = edges[i, 0] };
						map.Add(edges[i, 0], n0);
					}
					if (!map.TryGetValue(edges[i, 1], out n1))
					{
						n1 = new Node() { val = edges[i, 1] };
						map.Add(edges[i, 1], n1);
					}
					n0.children.Add(n1);
					n1.children.Add(n0);
				}

				var resp = new List<int>();
				if (map.Count > 0)
				{
					//Randomly select a node x as the root, do a dfs/ bfs to find the node y that has the longest distance from x.
					//Then y must be one of the endpoints on some longest path.
					//Let y the new root, and do another dfs/ bfs.Find the node z that has the longest distance from y.
					//Now, the path from y to z is the longest one, and thus its middle point(s) is the answer.
					 var lastNode = GetTreeMaxHNode(map.FirstOrDefault().Value);
					lastNode = GetTreeMaxHNode(map[lastNode]);
					lastNode = GetTreeMaxHNode(map[lastNode]);
					var path = GetTreeH(map[lastNode], null);
					var index = path.Count / 2;
					var getPrev = path.Count % 2 == 0;
					resp.Add(path[index]);
					if (getPrev) resp.Add(path[index - 1]);
				}
				if (resp.Count == 0) return Enumerable.Range(0, n).ToList();
				return resp;
			}

			private List<int> GetTreeH(Node n, Node prev)
			{
				var maxPath = new List<int>();
				foreach (var c in n.children)
				{
					if (c != prev)
					{
						var path = GetTreeH(c, n);
						if (path.Count > maxPath.Count)
						{
							maxPath = new List<int>(path);
						}
					}
				}
				maxPath.Add(n.val);
				return maxPath;
			}

			private int GetTreeMaxHNode(Node n)
			{
				var q = new Queue<Node>();
				var v = new HashSet<int>() { n.val };
				q.Enqueue(n);
				Node prev = null;
				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					foreach (var c in curr.children)
					{
						if (v.Add(c.val))
						{
							q.Enqueue(c);
						}
					}
					prev = curr;
				}
				return prev.val;
			}
		}
    }
}
