using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewUberPhoneTreeLevelPrint_Ivan
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question #1
            //var stree = "1,2,4,6,8,n,n,n,n,5,n,7,n,9,n,n,3,n,n";
            var stree = "1,2,4,n,n,5,n,n,3,6,n,n,7,8,n,n,n";
            var tree = TreeSerializer.Deserialize(stree);
            var treeByLevelBsf = GetTreeByLevelBsf(tree);
            var treeByLevelDsf = GetTreeByLevelDsf(tree);
        }

        public static List<List<int>> GetTreeByLevelBsf(Node r)
        {
            var resp = new List<List<int>>();
            var q1 = new Queue<Node>();
            var q2 = new Queue<Node>();
            q1.Enqueue(r);
            while (q1.Count > 0 || q2.Count > 0)
            {
                if(q1.Count > 0) resp.Add(new List<int>());
                while (q1.Count > 0)
                {
                    var curr = q1.Dequeue();
                    resp.Last().Add(curr.value);
                    if(curr.left != null) q2.Enqueue(curr.left);
                    if(curr.right != null) q2.Enqueue(curr.right);
                }
                if (q2.Count > 0) resp.Add(new List<int>());
                while (q2.Count > 0)
                {
                    var curr = q2.Dequeue();
                    resp.Last().Add(curr.value);
                    if (curr.left != null) q1.Enqueue(curr.left);
                    if (curr.right != null) q1.Enqueue(curr.right);
                }
            }
            return resp;
        }

        public static List<List<int>> GetTreeByLevelDsf(Node r)
        {
            var resp = new List<List<int>>();
            GetTreeByLevelDsf(r, resp, 0);
            return resp;
        }

        public static void GetTreeByLevelDsf(Node r, List<List<int>> resp, int l)
        {
            if (r == null) return;
            if (l == resp.Count) resp.Add(new List<int>());
            resp[l].Add(r.value);
            GetTreeByLevelDsf(r.left, resp, l + 1);
            GetTreeByLevelDsf(r.right, resp, l + 1);
        }

        public class Node
        {
            public int value { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }
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
