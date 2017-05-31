using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesBstSequences
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = GetCombinations(new List<int> { 1, 2, 3 });
            var r = BuildMinimal(new List<int>() { 1, 2, 3, 4, 5, 6, 7 });
            //var resp = GetDepth(r);

            var resp = GetBstSequences(r);
        }

        public static List<List<int>> GetBstSequences(Node r)
        {
            var levels = GetDepth(r);
            var sLevels = new Stack<List<int>>();
            foreach (var l in levels) sLevels.Push(l);
            var downComb = GetCombinations(sLevels.Pop());
            while (sLevels.Count > 0)
            {
                var topComb = GetCombinations(sLevels.Pop());
                downComb = Combine(topComb, downComb);
            }

            return downComb;
        }

        public static List<List<int>> Combine(List<List<int>> combTop, List<List<int>> combDown)
        {
            var resp = new List<List<int>>();
            foreach (var top in combTop)
            {
                foreach (var down in combDown)
                {
                    var l = new List<int>(top);
                    l.AddRange(down);
                    resp.Add(l);
                }
            }

            return resp;
        }
        public static List<List<int>> GetCombinations(List<int> a)
        {
            var counters = Enumerable.Repeat(1, a.Count).ToList();
            var parc = new List<int>();
            var resp = new List<List<int>>();
            GetCombinations(a, resp, counters, parc);
            return resp;
        }

        public static void GetCombinations(List<int> a, List<List<int>> resp, List<int> counters, List<int> parc)
        {
            if (parc.Count == a.Count)
            {
                resp.Add(new List<int>(parc));
                return;
            }

            var localCounters = new List<int>(counters);
            for (int i = 0; i < localCounters.Count; ++i)
            {
                if (localCounters[i] == 1)
                {
                    localCounters[i] = 0;
                    parc.Add(a[i]);
                    GetCombinations(a, resp, localCounters, parc);
                    parc.RemoveAt(parc.Count - 1);
                    localCounters[i] = 1;
                }
            }
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
