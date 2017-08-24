using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode501.Find_Mode_in_Binary_Search_Tree
{
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

        public class Solution
        {
            public int[] FindMode(TreeNode root)
            {
                var max = 1;
                var map = new Dictionary<int,int>();
                FindMode(root, map, ref max);
                return map.Where(x => x.Value == max).ToList().Select(x => x.Key).ToArray();
            }
            private void FindMode(TreeNode n, Dictionary<int,int> map, ref int max)
            {
                if (n == null) return;
                var count = 0;
                if (map.TryGetValue(n.val, out count))
                {
                    map[n.val] = ++count;
                    max = Math.Max(max, count);
                }
                else map.Add(n.val, 1);
                FindMode(n.left, map, ref max);
                FindMode(n.right, map, ref max);
            }
        }
    }
}
