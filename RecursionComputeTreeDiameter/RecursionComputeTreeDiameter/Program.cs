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
            GetMaxDia(r);
        }

        public class Node
        {
            public Node left;
            public Node right;
            public int val;
        }

        public class MaxDia
        {
            public int dia;
            public Node root;
        }

        public static MaxDia max = new MaxDia();
        public static int GetMaxDia(Node n)
        {
            if (n == null) return 0;
            var l = GetMaxDia(n.left);
            var r = GetMaxDia(n.right);
            var localDia = l + r + 1;
            if (localDia > max.dia)
            {
                max.dia = localDia;
                max.root = n;
            }

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
