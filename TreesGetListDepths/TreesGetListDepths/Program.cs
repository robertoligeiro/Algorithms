using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesGetListDepths
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = BuildMinimal(new List<int>() { 1, 2, 3, 4, 5, 6 });
            var resp = GetDepth(r);
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
        }

        public static List<List<int>> GetDepth(Node r)
        {
            var resp = new List<List<int>>();
            GetDepth(r, resp, 0);
            return resp;
        }
        public static void GetDepth(Node r, List<List<int>> resp, int h)
        {
            if (r == null) return;
            if (resp.Count == h) resp.Add(new List<int>());
            resp[h].Add(r.val);
            GetDepth(r.left, resp, h + 1);
            GetDepth(r.right, resp, h + 1);
        }
        public static Node BuildMinimal(List<int> a)
        {
            return BuildMinimal(a, 0, a.Count - 1);
        }
        public static Node BuildMinimal(List<int> a, int l, int r)
        {
            if (l > r) return null;
            var mid = l + (r - l) / 2;
            var root = new Node() { val = a[mid] };
            root.left = BuildMinimal(a, l, mid - 1);
            root.right = BuildMinimal(a, mid + 1, r);
            return root;
        }
    }
}
