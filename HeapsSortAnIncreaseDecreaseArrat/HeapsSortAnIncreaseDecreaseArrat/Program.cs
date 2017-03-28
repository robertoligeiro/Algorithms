using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsSortAnIncreaseDecreaseArrat
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 57, 131, 493, 294, 221, 339, 418, 452, 442, 190 };
            var r = Sort(l);
        }

        public static List<int> Sort(List<int> a)
        {
            var l = new List<List<int>>();
            var isInc = true;
            var prev = a.FirstOrDefault();
            l.Add(new List<int>() { prev });
            a.RemoveAt(0);
            foreach (var i in a)
            {
                if (prev < i && !isInc)
                {
                    l.Add(new List<int>());
                    isInc = true;
                }
                else if (prev > i && isInc)
                {
                    l.Add(new List<int>());
                    isInc = false;
                }
                prev = i;
                l.LastOrDefault().Add(i);
            }

            return MergeLists(l);
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
