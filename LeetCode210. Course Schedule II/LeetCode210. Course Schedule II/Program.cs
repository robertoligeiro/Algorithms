using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode210.Course_Schedule_II
{
	//https://leetcode.com/problems/course-schedule-ii/description/
	class Program
	{
		static void Main(string[] args)
		{
			var s = new Solution();
			var r = s.FindOrder(4, new int[,] { { 1, 0 }, { 2, 0 }, { 3, 1 }, { 3, 2 } });
			//			var r = s.FindOrder(1, new int[,] { });
			//var r = s.FindOrder(3, new int[,] { { 1,2} });
			//var r = s.FindOrder(3, new int[,] { { 0,1}, { 0,2}, {1,2 } });
			//var r = s.FindOrder(10, new int[,] { { 5, 8 }, { 3, 5 }, { 1, 9 }, { 4, 5 }, { 0, 2 }, { 7, 8 }, { 4, 9 } });
		}

		public class Node
		{
			public int id;
			public List<Node> children = new List<Node>();
			public HashSet<int> dependency = new HashSet<int>();
		}
		public class Solution
		{
			public int[] FindOrder(int numCourses, int[,] prerequisites)
			{
				if (prerequisites.Length == 0)
				{
					return Enumerable.Range(0, numCourses).ToArray();
				}
				var map = new Dictionary<int, Node>();
				var idsNotInPre = new HashSet<int>(Enumerable.Range(0, numCourses).ToArray());
				//build graph
				for (int i = 0; i < prerequisites.GetLength(0); ++i)
				{
					var childId = prerequisites[i, 0];
					var parentId = prerequisites[i, 1];
					idsNotInPre.Remove(childId);
					idsNotInPre.Remove(parentId);
					Node childNode;
					if (!map.TryGetValue(childId, out childNode))
					{
						childNode = new Node() { id = childId };
						map.Add(childId, childNode);
					}
					childNode.dependency.Add(parentId);

					Node parentNode;
					if (!map.TryGetValue(parentId, out parentNode))
					{
						parentNode = new Node() { id = parentId };
						map.Add(parentId, parentNode);
					}
					parentNode.children.Add(childNode);
				}

				var resp = new List<int>(idsNotInPre);
				var inResp = new HashSet<int>(resp);

				foreach (var node in map.Values)
				{
					if (node.dependency.Count == 0)
					{
						GetCourses(node, resp, numCourses, inResp);
						if (resp.Count == numCourses) break;
					}
				}
				if (resp.Count == numCourses) return resp.ToArray();
				return new int[0];
			}

			public void GetCourses(Node root, List<int> courses, int numCourses, HashSet<int> inResp)
			{
				var q = new Queue<Node>();
				q.Enqueue(root);
				var visited = new HashSet<int>();
				while (q.Count > 0)
				{
					var curr = q.Dequeue();
					if (curr.dependency.Count == 0)
					{
						if (visited.Add(curr.id))
						{
							if(inResp.Add(curr.id)) courses.Add(curr.id);
							if (courses.Count == numCourses) return;
							foreach (var child in curr.children)
							{
								q.Enqueue(child);
								child.dependency.Remove(curr.id);
							}
						}
					}
				}
			}
		}
	}
}
