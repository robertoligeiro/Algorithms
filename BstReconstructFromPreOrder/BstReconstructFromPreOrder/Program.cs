using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstReconstructFromPreOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var t0 = ReconstructFromPreOrder(new List<int>() { 5,3,1,4,7,6});
            var t1 = ReconstructFromPreOrder(new List<int>() { 3, 1, 7, 5, 6, 8 });
        }
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        public static TreeNode ReconstructFromPreOrder(List<int> l)
        {
            if (l.Count == 0) return null;
            var r = new TreeNode() { val = l[0] };
            l.RemoveAt(0);
            if (l.Count == 0) return r;

            var index = FindIndex(r.val, l);
            var left = new List<int>();
            var right = new List<int>();
            if (index > 0) left.AddRange(l.GetRange(0, index));
            if(index > 0) right.AddRange(l.GetRange(index, l.Count - index));
            if (index == 0)
            {
                if (l[0] > r.val) right.AddRange(l);
                else left.AddRange(l);
            }
            r.left = ReconstructFromPreOrder(left);
            r.right = ReconstructFromPreOrder(right);
            return r;
        }

        public static int FindIndex(int val, List<int> l)
        {
            var left = 0;
            var right = l.Count - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (l[mid] > val) right = mid - 1;
                else left = mid + 1;
            }
            return left;
        }
    }
}
