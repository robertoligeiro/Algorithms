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
            var r = GetTrees(4);
            r = GetTrees(3);
        }

        public class Node
        {
            public Node left;
            public Node right;
            public int val;
        }

        public static List<Node> GetTrees(int n)
        {
            var values = Enumerable.Range(1, n).ToList();
            return GetTrees(values);
        }
        public static List<Node> GetTrees(List<int> values)
        {
            if (values == null) return new List<Node> { new Node() { val = -1 } };

            var trees = new List<Node>();
            for (int i = 0; i < values.Count; ++i)
            {
                var left = i == 0 ? null : values.GetRange(0, i);
                var right = i == values.Count - 1 ? null : values.GetRange(i + 1, values.Count - i - 1);
                var leftTrees = GetTrees(left);
                var rightTrees = GetTrees(right);
                CombineTrees(values[i], leftTrees, rightTrees, trees);
            }
            return trees;
        }
        public static void CombineTrees(int n, List<Node> left, List<Node> right, List<Node> trees)
        {
            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    var node = new Node() { val = n };
                    node.left = l.val == -1 ? null : l;
                    node.right = r.val == -1 ? null : r;
                    trees.Add(node);
                }
            }
        }
    }
}
