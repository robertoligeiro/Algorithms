using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgrammingGetMinPathInTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var n0 = new Node() { val = 2 };
            var n11 = new Node() { val = 3 };
            var n12 = new Node() { val = 4 };
            var n21 = new Node() { val = 1 };
            var n22 = new Node() { val = 0 };
            var n23 = new Node() { val = 0 };
            var n31 = new Node() { val = 2 };
            var n32 = new Node() { val = 3 };
            var n33 = new Node() { val = 4 };
            var n34 = new Node() { val = 1 };

            n0.left = n11;
            n0.right = n12;
            n11.left = n21;
            n11.right = n22;
            n12.left = n22;
            n12.right = n23;
            n21.left = n31;
            n21.right = n32;
            n22.left = n32;
            n22.right = n33;
            n23.left = n33;
            n23.right = n34;

            var r = GetMinPath(n0);
        }

        public class Node
        {
            public int val { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
        }

        public static int GetMinPath(Node start)
        {
            var visited = new Dictionary<Node, int>();
            return GetMinPath(start, visited);
        }
        public static int GetMinPath(Node n, Dictionary<Node, int> v)
        {
            int left;
            if (n.left == null)
            {
                left = 0;
            }else
            if (!v.TryGetValue(n.left, out left))
            {
                left = GetMinPath(n.left, v);
            }

            int right;
            if (n.right == null)
            {
                right = 0;
            }else
            if (!v.TryGetValue(n.right, out right))
            {
                right = GetMinPath(n.right, v);
            }

            int val = Math.Min(left, right) + n.val;
            if (!v.ContainsKey(n))
            {
                v.Add(n, val);
            }

            return val;
        }
    }
}
