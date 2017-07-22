using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewAmazonOnSite
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question #1
            var stree = "1,2,4,6,8,n,n,n,n,5,n,7,n,9,n,n,3,n,n";
            var tree = TreeSerializer.Deserialize(stree);
            var streeCheck = TreeSerializer.Serialize(tree);

            // Question #2
            var maxDiameter = GetMaxDiameter(tree);
        }

        public class Node
        {
            public int value { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
        }

        // Coding question #1
        public static int GetMaxDiameter(Node n)
        {
            var maxD = 0;
            GetMaxDiameter(n, ref maxD);
            return maxD;
        }
        public static int GetMaxDiameter(Node n, ref int maxD)
        {
            if (n == null) return 0;
            var l = GetMaxDiameter(n.left, ref maxD);
            var r = GetMaxDiameter(n.right, ref maxD);
            var localDiameter = l + r + 1;
            maxD = Math.Max(maxD, localDiameter);
            return Math.Max(l,r) + 1;
        }

        // Coding question #2
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
