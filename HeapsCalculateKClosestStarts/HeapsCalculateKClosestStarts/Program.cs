using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsCalculateKClosestStarts
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dictionary<string, List<int>>()
            {
                { "marte", new List<int>() { 2, 1, 3 } },
                { "plutao", new List<int>() { 6, 6, 6 } },
                { "lua", new List<int>() { 1, 1, 1 } },
                { "urano", new List<int>() { 3, 3, 2 } },
                { "saturno", new List<int>() { 3, 3, 1 } },
            };

            var r = Sort(d, 3);
        }

        public static List<string> Sort(Dictionary<string, List<int>> a, int k)
        {
            var sDict = new SortedDictionary<double, string>();
            for (int i = 0; i < k; ++i)
            {
                sDict.Add(GetDistance(a.ElementAt(i).Value), a.ElementAt(i).Key);
            }

            for (int i = k + 1; i < a.Count; ++i)
            {
                var dist = GetDistance(a.ElementAt(i).Value);
                var max = sDict.LastOrDefault();
                if (max.Key > dist)
                {
                    sDict.Remove(max.Key);
                    sDict.Add(dist, a.ElementAt(i).Key);
                }
            }
            return sDict.Values.ToList();
        }

        public static bool IsCloser(List<int> a, List<int> b)
        {
            return GetDistance(a) < GetDistance(b);
        }

        public static double GetDistance(List<int> a)
        {
            return Math.Sqrt(a[0] * a[0] + a[1] * a[1] + a[2] * a[2]);
        }
    }
}
