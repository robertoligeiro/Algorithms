using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonComputerTestCreateTreeGetDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 2, 4);
            r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 5, 3);
            r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 5, 1);
            r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 3, 7);
            r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 2, 7);
            r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 4, 7);
            r = CreateTreeAndGetDistance(new int[] { 5, 3, 1, 2, 4, 7 }, 6, 7, 1);
        }

        public class Node
        {
            public Node left;
            public Node right;
            public Node parent;
            public int h;
            public int val;
        }

        public class Found
        {
            public int found;
            public int dist;
        }
        public static int CreateTreeAndGetDistance(int[] values, int n, int node1, int node2)
        {
            Node n1;
            Node n2;
            var r = CreateTreeCheckNodesExist(values, n, node1, node2, out n1, out n2);
            if (r != null)
            {
                if (node1 == node2) return 0;
                //return GetDistance(n1, n2);
                var ret = GetDistance(r, node1, node2, new Found());
                return ret.dist;
            }
            return -1;
        }

        public static Found GetDistance(Node r, int i, int j, Found f)
        {
            if (r == null) return f;
            var left = GetDistance(r.left, i, j, f);
            if (left.found == 1) left.dist++;
            if (r.val == i || r.val == j)
            {
                if (++left.found == 2) return left;
            }
            var right = new Found() { dist = left.dist, found = left.found };
            right = GetDistance(r.right, i, j, right);
            if (right.found == 2) return right;
            if (right.found == 1) right.dist++;
            return left.found == 1? left : right;
        }

        public static int GetDistance(Node node1, Node node2)
        {
            var diff = Math.Abs(node1.h - node2.h);
            var dist = diff;
            if (node1.h > node2.h)
            {
                while (diff > 0)
                {
                    diff--;
                    node1 = node1.parent;
                }
            }
            if (node2.h > node1.h)
            {
                while (diff > 0)
                {
                    diff--;
                    node2 = node2.parent;
                }
            }

            if (node1 == node2) return dist;
            dist++;
            while (node1 != node2)
            {
                node2 = node2.parent;
                node1 = node1.parent;
                dist++;
            }
            return dist;
        }

        public static Node CreateTreeCheckNodesExist(int[] values, int n, int node1, int node2, out Node n1, out Node n2)
        {
            n1 = new Node();
            n2 = new Node();
            if (n == 0) return null;

            bool fn1 = false;
            bool fn2 = false;

            var root = new Node() { val = values[0] };
            if (values[0] == node1)
            {
                n1 = root;
                fn1 = true;
            }
            if (values[0] == node2)
            {
                n2 = root;
                fn2 = true;
            }
            for (int i = 1; i < n; ++i)
            {
                var t = AddNode(root, values[i], 0);
                if (values[i] == node1)
                {
                    n1 = t;
                    fn1 = true;
                }
                if (values[i] == node2)
                {
                    n2 = t;
                    fn2 = true;
                }
            }
            return fn1 && fn2 ? root: null;
        }

        public static Node AddNode(Node r, int v, int h)
        {
            h++;
            if (r.val > v)
            {
                if (r.left == null)
                {
                    r.left = new Node() { val = v, parent = r , h = h};
                    return r.left;
                }
                else
                {
                    return AddNode(r.left, v, h);
                }
            }
            else
            {
                if (r.right == null)
                {
                    r.right = new Node() { val = v, parent = r , h  = h};
                    return r.right;
                }
                else
                {
                    return AddNode(r.right, v, h);
                }
            }

        }
    }
}
