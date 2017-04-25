using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstGetInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = Insert(null, 19);
            //left tree
            Insert(root, 7);
            Insert(root, 3);
            Insert(root, 2);
            Insert(root, 5);
            Insert(root, 11);
            Insert(root, 17);
            Insert(root, 13);

            //right
            Insert(root, 43);
            Insert(root, 23);
            Insert(root, 37);
            Insert(root, 29);
            Insert(root, 41);
            Insert(root, 31);
            Insert(root, 47);
            Insert(root, 53);
            //var b = GetInterval(root, new Tuple<int, int>(16,31));
            var b = GetInterval(root, new Tuple<int, int>(20, 42));
        }

        public static List<TreeNode> GetInterval(TreeNode r, Tuple<int, int> inter)
        {
            var response = new List<TreeNode>();
            GetInterval(r, inter, response);
            return response;
        }
        public static void GetInterval(TreeNode r, Tuple<int, int> inter, List<TreeNode> l)
        {
            Console.WriteLine("visited: {0}", r != null ? r.val : 0);
            if (r == null) return;
            if (r.val > inter.Item1) GetInterval(r.left, inter, l);
            if (r.val >= inter.Item1 && r.val <= inter.Item2) l.Add(r);
            if (r.val < inter.Item2) GetInterval(r.right, inter, l);
        }
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }


        public static TreeNode GetNode(TreeNode r, int val)
        {
            if (r == null) return null;
            if (r.val == val) return r;
            if (r.val > val) return GetNode(r.left, val);
            return GetNode(r.right, val);
        }
        public static TreeNode Insert(TreeNode r, int val)
        {
            if (r == null)
            {
                return new TreeNode() { val = val };
            }

            if (r.val == val) return r;
            if (r.val > val) r.left = Insert(r.left, val);
            else r.right = Insert(r.right, val);
            return r;
        }
    }
}
