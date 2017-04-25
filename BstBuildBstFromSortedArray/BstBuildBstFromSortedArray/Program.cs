using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstBuildBstFromSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BuildBst(new List<int>() { 1,2,3,4,5,6});
        }
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        public static TreeNode BuildBst(List<int> a)
        {
            if (a == null || a.Count == 0) return null;
            return BuildBst(a, 0, a.Count - 1);
        }
        public static TreeNode BuildBst(List<int> a, int left, int right)
        {
            if (left > right) return null;
            var mid = left + (right - left) / 2;
            var node = new TreeNode() { val = a[mid] };
            node.left = BuildBst(a, left, mid - 1);
            node.right = BuildBst(a, mid + 1, right);
            return node;
        }
    }
}
