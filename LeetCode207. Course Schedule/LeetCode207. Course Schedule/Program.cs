using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode207.Course_Schedule
{
    class Program
    {
        //https://leetcode.com/problems/course-schedule/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.CanFinish(2, new int[,] { { 1, 0 } });
            r = s.CanFinish(2, new int[,] { { 1, 0 }, { 0,1} });
            r = s.CanFinish(3, new int[,] { { 1, 0 } });
        }

        public class Node
        {
            public HashSet<int> parents = new HashSet<int>();
            public int val;
            public List<Node> children = new List<Node>();
        }
        public class Solution
        {
            public bool CanFinish(int numCourses, int[,] prerequisites)
            {
                if (numCourses == 0) return true;
                if (prerequisites == null) return false;
                if (prerequisites.GetLength(0) == 0) return true;
                //Build graph
                var nodes = new Dictionary<int, Node>();
                var roots = new Dictionary<int, Node>();
                for (int i = 0; i < prerequisites.GetLength(0); ++i)
                {
                    var parentId = prerequisites[i, 1];
                    var childId = prerequisites[i, 0];
                    Node parent;
                    Node child;
                    if (!nodes.TryGetValue(parentId, out parent))
                    {
                        parent = new Node() { val = parentId };
                        roots.Add(parentId, parent);
                        nodes.Add(parentId, parent);
                    }

                    if (!nodes.TryGetValue(childId, out child))
                    {
                        child = new Node() { val = childId };
                        nodes.Add(childId, child);
                    }

                    parent.children.Add(child);
                    child.parents.Add(parentId);
                    if (roots.ContainsKey(childId)) roots.Remove(childId);
                }

                for (int i = 0; i < numCourses; ++i)
                {
                    Node parent;
                    if (!nodes.TryGetValue(i, out parent))
                    {
                        parent = new Node() { val = i };
                        roots.Add(i, parent);
                    }
                }

                var coursesTaken = new HashSet<int>();
                foreach (var root in roots.Values)
                {
                    var q = new Queue<Node>();
                    q.Enqueue(root);
                    while (q.Count > 0)
                    {
                        var curr = q.Dequeue();
                        if (curr.parents.Count == 0)
                        {
                            coursesTaken.Add(curr.val);
                            if (coursesTaken.Count == numCourses) return true;
                        }
                        foreach (var child in curr.children)
                        {
                            if (child.parents.Remove(curr.val) && child.parents.Count == 0)
                            {
                                q.Enqueue(child);
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}
