using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BstFindTheClosestInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindClosestInterval(new List<List<int>>()
            {
                new List<int>(){ 5,10,15 },
                new List<int>(){ 3,6,9,12,15 },
                new List<int>(){ 8,16,24},
            });
        }

        public static List<int> FindClosestInterval(List<List<int>> a)
        {
            var resp = new List<int>();
            var d = new SortedDictionary<int, List<int>>();
            for (int i = 0; i < a.Count; ++i)
            {
                AddToDictionary(a[i][0], i, d);
                a[i].RemoveAt(0);
            }
            var minSoFar = int.MaxValue;

            while (true)
            {
                var currDist = 0;
                var prev = d.Keys.First();
                for (int i = 1; i < d.Count; ++i)
                {
                   currDist += Math.Abs(d.Keys.ElementAt(i) - prev);
                   prev = d.Keys.ElementAt(i);
                }
                if (currDist < minSoFar)
                {
                    minSoFar = currDist;
                    resp = d.Select(x => x.Key).ToList();
                }

                var t = d.FirstOrDefault();

                var nextList = t.Value.FirstOrDefault();
                if (a[nextList].Count == 0) break;

                t.Value.RemoveAt(0);
                AddToDictionary(a[nextList][0], nextList, d);
                a[nextList].RemoveAt(0);
                if (t.Value.Count == 0) d.Remove(t.Key);
            }

            return resp;
        }

        public static void AddToDictionary(int key, int val, SortedDictionary<int, List<int>> d)
        {
            List<int> l;
            if (d.TryGetValue(key, out l))
            {
                l.Add(val);
            }
            else
                d.Add(key, new List<int>() { val });
        }
    }
}
