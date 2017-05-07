using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeCloneGraph
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        
          //Definition for undirected graph.
          public class UndirectedGraphNode {
              public int label;
              public IList<UndirectedGraphNode> neighbors;
              public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
         };
         
        public class Solution
        {
            public UndirectedGraphNode CloneGraph(UndirectedGraphNode node)
            {
                if (node == null) return null;
                var q = new Queue<UndirectedGraphNode>();
                q.Enqueue(node);
                var v = new HashSet<UndirectedGraphNode>();
                v.Add(node);
                var created = new Dictionary<int, UndirectedGraphNode>();
                var newRoot = new UndirectedGraphNode(node.label);
                created.Add(newRoot.label, newRoot);
                while (q.Count > 0)
                {

                    var curr = q.Dequeue();
                    var currNew = created[curr.label];

                    foreach (var c in curr.neighbors)
                    {
                        if (v.Add(c)) q.Enqueue(c);

                        UndirectedGraphNode newChild;
                        if (created.TryGetValue(c.label, out newChild))
                        {
                            currNew.neighbors.Add(newChild);
                        }
                        else
                        {
                            newChild = new UndirectedGraphNode(c.label);
                            currNew.neighbors.Add(newChild);
                            created.Add(newChild.label, newChild);
                        }
                    }
                }

                return newRoot;
            }
        }
    }
}
