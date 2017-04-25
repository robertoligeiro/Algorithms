using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstCountNodesInTheInterval
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public int countLeft { get; set; }
            public int countRight { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        static void Main(string[] args)
        {
            var n5 = new TreeNode { val = 5, countLeft = 3, countRight = 3 };
            var n3 = new TreeNode { val = 3, countLeft = 1, countRight = 1 };
            var n1 = new TreeNode { val = 1, countLeft = 0, countRight = 0 };
            var n4 = new TreeNode { val = 4, countLeft = 0, countRight = 0 };
            var n10 = new TreeNode { val = 10, countLeft = 2, countRight = 0 };
            var n7 = new TreeNode { val = 7, countLeft = 0, countRight = 1 };
            var n9 = new TreeNode { val = 9, countLeft = 0, countRight = 0 };
            n5.left = n3;
            n5.right = n10;
            n3.left = n1;
            n3.right = n4;
            n10.left = n7;
            n7.right = n9;

            var r = GetIntervalCount(n5, new Tuple<int, int>(4, 8));
        }

        public static int GetIntervalCount(TreeNode r, Tuple<int, int> inter)
        {
            var smaller = GetSmallers(r, inter.Item1, 0);
            var greater = GetGreaters(r, inter.Item2, 0);
            return (r.countLeft + r.countRight + 1) - (smaller + greater);
        }
        public static int GetSmallers(TreeNode r, int v, int count)
        {
            if (r == null) return count;
            if (r.val >= v) return GetSmallers(r.left, v, count);
            return GetSmallers(r.right, v, count + r.countLeft + 1);
        }
        public static int GetGreaters(TreeNode r, int v, int count)
        {
            if (r == null) return count;
            if (r.val <= v) return GetGreaters(r.right, v, count);
            return GetGreaters(r.left, v, count + r.countRight + 1);
        }
    }
}
