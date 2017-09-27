using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _116.PopulatingNextRightPointersinEachNode
{
    class Program
    {
        //https://leetcode.com/problems/populating-next-right-pointers-in-each-node/description/
        static void Main(string[] args)
        {
            var stree = "1,2,4,6,8,n,n,n,n,5,n,7,n,9,n,n,3,n,n";
            var tree = TreeSerializer.Deserialize(stree);
            ConnectTree(tree);
        }

        public static void ConnectTree(Node n)
        {
            if (n == null) return;
            var q1 = new Queue<Node>();
            var q2 = new Queue<Node>();
            q1.Enqueue(n);
            while (q1.Count > 0 || q2.Count > 0)
            {
                FillNextAndQueue(q1, q2);
                FillNextAndQueue(q2, q1);
            }
        }

        public static void FillNextAndQueue(Queue<Node> from, Queue<Node> to)
        {
            Node prev = null;
            while (from.Count > 0)
            {
                var curr = from.Dequeue();
                curr.next = prev;
                prev = curr;
                if (curr.right != null) to.Enqueue(curr.right);
                if (curr.left != null) to.Enqueue(curr.left);
            }
        }

        public class Node
        {
            public int value { get; set; }
            public Node left { get; set; }
            public Node next { get; set; }
            public Node right { get; set; }
        }

        public static class TreeSerializer
        {
            public static string Serialize(Node root)
            {
                var tree = new List<string>();
                Serialize(root, tree);
                return string.Join(",", tree);
            }
            private static void Serialize(Node root, List<string> tree)
            {
                if (root == null)
                {
                    tree.Add("n");
                    return;
                }

                tree.Add(root.value.ToString());
                Serialize(root.left, tree);
                Serialize(root.right, tree);
            }
            public static Node Deserialize(string tree)
            {
                var q = new Queue<string>(tree.Split(','));
                return Deserialize(q);
            }
            private static Node Deserialize(Queue<string> q)
            {
                var n = q.Dequeue();
                if (n == "n") return null;
                var node = new Node() { value = int.Parse(n) };
                node.left = Deserialize(q);
                node.right = Deserialize(q);
                return node;
            }
        }

    }
}
