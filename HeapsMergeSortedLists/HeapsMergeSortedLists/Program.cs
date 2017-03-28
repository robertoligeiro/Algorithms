using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsMergeSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<List<int>>() { new List<int>() { 3, 5, 7 }, new List<int>() { 0, 6 }, new List<int>() { 0, 6, 28 } };
            var r = MergeLists(l);
        }

        public static List<int> MergeLists(List<List<int>> a)
        {
            var r = new List<int>();
            var sDict = new SortedDictionary<int, List<int>>();
            while (true)
            {
                for (int i = 0; i < a.Count; ++i)
                {
                    if (a[i].Count > 0)
                    {
                        List<int> l;
                        if (sDict.TryGetValue(a[i][0], out l))
                        {
                            l.Add(i);
                        }
                        else
                        {
                            sDict.Add(a[i][0], new List<int>() { i });
                        }
                        a[i].RemoveAt(0);
                    }
                }

                if (sDict.Count > 0)
                {
                    var t = sDict.ElementAt(0);
                    foreach (var index in t.Value)
                    {
                        r.Add(t.Key);
                    }
                    sDict.Remove(t.Key);
                }
                else return r;
            }
        }
    }
}
