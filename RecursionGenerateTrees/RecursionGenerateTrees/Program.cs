using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionGenerateTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = GenerateTrees(4);
        }

        public class Node
        {
            public Node left;
            public Node right;
            public int val;
        }

        public static List<Node> GenerateTrees(int n)
        {
            var l = Enumerable.Range(1, n).ToList();
            return GenerateTrees(l);
        }

        public static List<Node> GenerateTrees(List<int> l)
        {
            if (l.Count == 0) return new List<Node>() { new Node { val = -1 } };

            var trees = new List<Node>();
            for (int i = 0; i < l.Count; ++i)
            {
                var left = l.GetRange(0, i);
                var right = l.GetRange(i + 1, l.Count - 1 - i);
                trees.AddRange(GenerateTrees(l[i], left, right));
            }
            return trees;
        }
        public static List<Node> GenerateTrees(int v, List<int> l, List<int> r)
        {
            var left = GenerateTrees(l);
            var right = GenerateTrees(r);
            var resp = new List<Node>();
            foreach (var nl in left)
            {
                foreach (var nr in right)
                {
                    var root = new Node() { val = v };
                    root.left = nl;
                    root.right = nr;
                    resp.Add(root);
                }
            }

            return resp;
        }

    }
}
