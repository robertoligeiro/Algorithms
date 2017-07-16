using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionComputeTreeDiameter
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CreateTree(new int[] {10, 5, 4, 3, 1, 6, 7, 8, 11 });
            var resp = GetTreeMaxDiameter(r);
        }

        public class Node
        {
            public Node left;
            public Node right;
            public int val;
        }

        public static int GetTreeMaxDiameter(Node n)
        {
            var max = 0;
            GetTreeMaxDiameter(n, ref max);
            return max;
        }

        public static int GetTreeMaxDiameter(Node n, ref int max)
        {
            if (n == null) return 0;
            var l = GetTreeMaxDiameter(n.left, ref max);
            var r = GetTreeMaxDiameter(n.right, ref max);
            var dia = l + r + 1;
            max = Math.Max(max, dia);
            return Math.Max(l, r) + 1;
        }
        public static Node CreateTree(int[] values)
        {
            var root = new Node() { val = values[0] };
            for (int i = 1; i < values.Length; ++i)
            {
                AddNode(root, values[i]);
            }
            return root;
        }
        public static Node AddNode(Node r, int v)
        {
            if (r.val > v)
            {
                if (r.left == null)
                {
                    r.left = new Node() { val = v };
                    return r.left;
                }
                else
                {
                    return AddNode(r.left, v);
                }
            }
            else
            {
                if (r.right == null)
                {
                    r.right = new Node() { val = v };
                    return r.right;
                }
                else
                {
                    return AddNode(r.right, v);
                }
            }

        }
    }
}
