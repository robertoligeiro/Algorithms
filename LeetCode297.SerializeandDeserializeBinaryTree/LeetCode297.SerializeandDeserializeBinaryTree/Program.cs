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

        // Your Codec object will be instantiated and called as such:
        // Codec codec = new Codec();
        // codec.deserialize(codec.serialize(root));
    }
}
