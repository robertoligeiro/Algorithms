using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode449.SerializeandDeserializeBST
{
    //https://leetcode.com/problems/serialize-and-deserialize-bst/#/description
    class Program
    {
        static void Main(string[] args)
        {
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
 
        public class Codec
        {

            // Encodes a tree to a single string.
            public string serialize(TreeNode root)
            {
                var tree = new List<string>();
                serialize(root, tree);
                return string.Join(",", tree);
            }

            private void serialize(TreeNode n, List<string> tree)
            {
                if (n == null)
                {
                    tree.Add("n");
                    return;
                }
                tree.Add(n.val.ToString());
                serialize(n.left, tree);
                serialize(n.right, tree);
            }

            // Decodes your encoded data to tree.
            public TreeNode deserialize(string data)
            {
                var treeQueue = new Queue<string>(data.Split(','));
                return deserialize(treeQueue);
            }

            private TreeNode deserialize(Queue<string> treeQueue)
            {
                var n = treeQueue.Dequeue();
                if (n == "n") return null;
                var node = new TreeNode(int.Parse(n));
                node.left = deserialize(treeQueue);
                node.right = deserialize(treeQueue);
                return node;
            }
        }
    }
}
