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
            var r = s.FindMinHeightTrees(6, new int[,] { { 0,3 }, { 1, 3 }, { 2,3} ,{ 4,3}, { 5,4} });
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

                //get node with min h
                var resp = new SortedDictionary<int, List<int>>();
                foreach (var g in map.Values)
                {
                    var h = GetH(g);
                    List<int> l;
                    if (resp.TryGetValue(h, out l)) l.Add(g.val);
                    else resp.Add(h, new List<int>() { g.val });
                }
                if (resp.Count == 0) return Enumerable.Range(0, n).ToList();
                return resp.FirstOrDefault().Value;
            }

            private int GetH(Node n)
            {
                var q1 = new Queue<Node>();
                var q2 = new Queue<Node>();
                var v = new HashSet<Node>();
                var h = 0;
                q1.Enqueue(n);
                v.Add(n);
                while (q1.Count > 0 || q2.Count > 0)
                {
                    UnloadQueue(q1, q2, v);
                    if (q1.Count == 0 && q2.Count == 0) break;
                    h++;
                    UnloadQueue(q2, q1, v);
                    if (q1.Count == 0 && q2.Count == 0) break;
                    h++;
                }
                return h;
            }

            private void UnloadQueue(Queue<Node> from, Queue<Node> to, HashSet<Node> v)
            {
                while (from.Count > 0)
                {
                    var curr = from.Dequeue();
                    foreach (var c in curr.children)
                    {
                        if(v.Add(c)) to.Enqueue(c);
                    }
                }
            }
        }
    }
}
