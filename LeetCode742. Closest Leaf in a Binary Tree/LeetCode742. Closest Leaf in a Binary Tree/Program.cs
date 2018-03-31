using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode742.Closest_Leaf_in_a_Binary_Tree
{
	class Program
	{
		//https://leetcode.com/problems/closest-leaf-in-a-binary-tree/description/
		static void Main(string[] args)
		{
		}

		public class TreeNode
		{
			public int val;
			public TreeNode left;
			public TreeNode right;
			public TreeNode(int x) { val = x; }
		}
		public class Solution
		{
			public class Dag
			{
				public bool isLeaf;
				public int val;
				public List<Dag> adj = new List<Dag>();
			}
			public int FindClosestLeaf(TreeNode root, int k)
			{
				if (root == null) return -1;
				var m = new Dictionary<int, Dag>();
				CreateDag(root, null, m);

				if (!m.ContainsKey(k)) return -1;

				var q1 = new Queue<Dag>();
				var q2 = new Queue<Dag>();
				q1.Enqueue(m[k]);
				var visited = new HashSet<int>() { k };
				var found = 0;
				while (q1.Count > 0 || q2.Count > 0)
				{
					found = MoveQueues(q1, q2, visited);
					if (found > 0) return found;
					found = MoveQueues(q2, q1, visited);
					if (found > 0) return found;
				}
				return -1;
			}

			private int MoveQueues(Queue<Dag> from, Queue<Dag> to, HashSet<int> visited)
			{
				while (from.Count > 0)
				{
					var curr = from.Dequeue();
					if (curr.isLeaf)
					{
						return curr.val;
					}
					foreach (var a in curr.adj)
					{
						if (visited.Add(a.val))
						{
							to.Enqueue(a);
						}
					}
				}
				return -1;
			}

			private void CreateDag(TreeNode n, Dag parent, Dictionary<int, Dag> m)
			{
				if (n == null) return;
				var d = new Dag() { val = n.val };
				d.isLeaf = n.left == null && n.right == null;
				if (parent != null)
				{
					parent.adj.Add(d);
					d.adj.Add(parent);
				}
				CreateDag(n.left, d, m);
				CreateDag(n.right, d, m);
				m.Add(d.val, d);
			}
		}
	}
}
