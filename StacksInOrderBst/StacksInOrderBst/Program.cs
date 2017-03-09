using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksInOrderBst
{
    class Program
    {
        public class TreeNode
        {
            public int val { get; set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }
        static void Main(string[] args)
        {
            var n5 = new TreeNode() { val = 5 };
            var n3 = new TreeNode() { val = 3 };
            var n1 = new TreeNode() { val = 1 };
            var n2 = new TreeNode() { val = 2 };
            var n7 = new TreeNode() { val = 7 };
            var n6 = new TreeNode() { val = 6 };
            var n8 = new TreeNode() { val = 8 };
            n5.left = n2;
            n5.right = n7;
            n2.left = n1;
            n2.right = n3;
            n7.left = n6;
            n7.right = n8;
            var r = InOrderBst(n5);
        }

        public static List<int> InOrderBst(TreeNode r)
        {
            var resp = new List<int>();
            var s = new Stack<TreeNode>();

            while (r != null || s.Count > 0)
            {
                if (r != null)
                {
                    s.Push(r);
                    r = r.left;
                }
                else
                {
                    if (s.Count > 0)
                    {
                        var t = s.Pop();
                        resp.Add(t.val);
                        r = t.right;
                    }
                }
            }
            return resp;
        }
    }
}
