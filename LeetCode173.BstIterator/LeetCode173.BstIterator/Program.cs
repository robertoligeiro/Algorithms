using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode173.BstIterator
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public class BSTIterator
        {
            private Stack<TreeNode> s;

            public BSTIterator(TreeNode root)
            {
                s = new Stack<TreeNode>();
                PopulateLeft(root);
            }

            private void PopulateLeft(TreeNode root)
            {
                while (root != null)
                {
                    s.Push(root);
                    root = root.left;
                }
            }
            /** @return whether we have a next smallest number */
            public bool HasNext()
            {
                return s.Count > 0;
            }

            /** @return the next smallest number */
            public int Next()
            {
                var ret = s.Pop();
                PopulateLeft(ret.right);
                return ret.val;
            }
        }

        /**
         * Your BSTIterator will be called like this:
         * BSTIterator i = new BSTIterator(root);
         * while (i.HasNext()) v[f()] = i.Next();
         */
    }
}
