using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode297.SerializeandDeserializeBinaryTree
{
    //https://leetcode.com/problems/serialize-and-deserialize-binary-tree/#/description
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Codec();
            var root = c.deserialize("5,3,7,1,null,6,null,null,null,null,null");
            var s = c.serialize(root);

            var root1 = TreeSerialization.Deserialize("5,3,1,null,null,null,7,6,null,null,null");
            var s1 = TreeSerialization.Serialize(root1);
        }

        public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
        public static class TreeSerialization
        {
            public static string Serialize(TreeNode n)
            {
                var resp = new List<string>();
                SerializePreOrder(n, resp);
                return string.Join(",", resp);
            }

            private static void SerializePreOrder(TreeNode n, List<string> s)
            {
                if (n == null)
                {
                    s.Add("null");
                    return;
                }
                s.Add(n.val.ToString());
                SerializePreOrder(n.left, s);
                SerializePreOrder(n.right, s);
            }

            public static TreeNode Deserialize(string tree)
            {
                var nodes = tree.Split(',');
                var q = new Queue<string>(nodes);
                return DeserializePreOrder(q);
            }

            private static TreeNode DeserializePreOrder(Queue<string> q)
            {
                var n = q.Dequeue();
                if (n == "null") return null;
                var node = new TreeNode(int.Parse(n));
                node.left = DeserializePreOrder(q);
                node.right = DeserializePreOrder(q);
                return node;
            }
        }
        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                if (root == null) return "null";
                var resp = new List<string>();
                var q = new Queue<Tuple<int, TreeNode>>();
                q.Enqueue(new Tuple<int, TreeNode>(root.val, root));
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    if (curr.Item2 == null)
                    {
                        resp.Add("null");
                        continue;
                    }

                    resp.Add(curr.Item1.ToString());
                    if (curr.Item2.left != null)
                    {
                        q.Enqueue(new Tuple<int, TreeNode>(curr.Item2.left.val, curr.Item2.left));
                    }else q.Enqueue(new Tuple<int, TreeNode>(-1, null));
                    if (curr.Item2.right != null)
                    {
                        q.Enqueue(new Tuple<int, TreeNode>(curr.Item2.right.val, curr.Item2.right));
                    }
                    else q.Enqueue(new Tuple<int, TreeNode>(-1, null));
                }
                return string.Join(",", resp);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                var nodes = data.Split(',');
                var root = nodes[0] != "null" ? new TreeNode(int.Parse(nodes[0])) : null;
                if (root == null) return null;
                var q = new Queue<TreeNode>();
                q.Enqueue(root);
                int index = 1;
                while (q.Count > 0)
                {
                    var curr = q.Dequeue();
                    curr.left = nodes[index] != "null" ? new TreeNode(int.Parse(nodes[index])) : null;
                    index++;
                    curr.right = nodes[index] != "null" ? new TreeNode(int.Parse(nodes[index])) : null;
                    index++;
                    if (curr.left != null) q.Enqueue(curr.left);
                    if (curr.right != null) q.Enqueue(curr.right);
                }
                return root;
            }
        }

        // Your Codec object will be instantiated and called as such:
        // Codec codec = new Codec();
        // codec.deserialize(codec.serialize(root));
    }
}
