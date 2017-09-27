using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode684.Redundant_Connection
{
    class Program
    {
        //https://leetcode.com/problems/redundant-connection/description/
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FindRedundantConnection(new int[,] { { 1, 2 }, { 1, 3 }, { 2, 3 } });
        }

        public enum State
        {
            None,
            Visiting,
            Visited
        }
        public class Node
        {
            public List<Node> ChilList = new List<Node>();
            public int nodeId { get; set; }
            public State nodeState { get; set; }
        }

        public class Solution
        {
            public int[] FindRedundantConnection(int[,] edges)
            {
                var nodes = new Dictionary<int, Node>();
                CreateNodes(nodes, edges);
                var loop = new HashSet<Tuple<int, int>>();
                Node loopStart = null;
                GetNodesInLoop(null, nodes.FirstOrDefault().Value, loop, ref loopStart);
                for (int i = edges.GetLength(0) - 1; i >= 0; --i)
                {
                    if (loop.Contains(new Tuple<int, int>(edges[i, 0], edges[i, 1])))
                        return new int[] { edges[i, 0], edges[i, 1] };
                }
                return null;
            }

            private bool GetNodesInLoop(Node parent, Node node, HashSet<Tuple<int, int>> loop, ref Node loopStart)
            {
                if (node.nodeState == State.Visiting)
                {
                    loop.Add(new Tuple<int, int>(node.nodeId, parent.nodeId));
                    loop.Add(new Tuple<int, int>(parent.nodeId, node.nodeId));
                    loopStart = node;
                    return false;
                }

                node.nodeState = State.Visiting;
                foreach (var child in node.ChilList)
                {
                    if (child != parent && loopStart == null)
                    {
                        if (!GetNodesInLoop(node, child, loop, ref loopStart))
                        {
                            if (parent != null && loopStart != node)
                            {
                                loop.Add(new Tuple<int, int>(parent.nodeId, node.nodeId));
                                loop.Add(new Tuple<int, int>(node.nodeId, parent.nodeId));
                            }
                            return loopStart == node;
                        }
                    }
                }
                node.nodeState = State.Visited;
                return true;
            }

            private void CreateNodes(Dictionary<int, Node> nodes, int[,] edges)
            {
                for (int i = 0; i < edges.GetLength(0); ++i)
                {
                    var n1Id = edges[i, 0];
                    var n2Id = edges[i, 1];
                    Node n1;
                    if (!nodes.TryGetValue(n1Id, out n1))
                    {
                        n1 = new Node() { nodeId = n1Id };
                        nodes.Add(n1Id, n1);
                    }
                    Node n2;
                    if (!nodes.TryGetValue(n2Id, out n2))
                    {
                        n2 = new Node() { nodeId = n2Id };
                        nodes.Add(n2Id, n2);
                    }
                    n1.ChilList.Add(n2);
                    n2.ChilList.Add(n1);
                }
            }
        }
    }
}
