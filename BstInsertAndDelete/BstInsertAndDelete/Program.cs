using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstInsertAndDelete
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = Insert(null, 5);
            Insert(root, 3);
            Insert(root, 1);
            Insert(root, 4);
            Insert(root, 10);
            Insert(root, 11);
            Insert(root, 8);
            Insert(root, 6);
            Insert(root, 7);

			root = Delete(root, 5);
			root = Delete(root, 10);
			root = Delete(root, 1);
            root = Delete(root, 3);
            root = Delete(root, 4);
            root = Delete(root, 10);
            root = Delete(root, 8);
            root = Delete(root, 11);
            root = Delete(root, 6);
            root = Delete(root, 7);
        }

        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
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

        public static TreeNode Delete(TreeNode r, int val)
        {
            if (r == null) return null;
			if (r.val > val)
			{
				r.left = Delete(r.left, val);
				return r;
			}
			if(r.val < val)
			{
				r.right = Delete(r.right, val);
				return r;
			}

            //leaf
            if (r.left == null && r.right == null) return null;
			
			//one child
			if (r.left == null || r.right == null)
			{
				return r.left == null ? r.right : r.left;
			}

            //both
            var leftMostRight = r.right;
            while (leftMostRight.left != null) leftMostRight = leftMostRight.left;
			var newVal = leftMostRight.val;
			Delete(r, newVal);
			r.val = newVal;
			return r;
        }
    }
}
