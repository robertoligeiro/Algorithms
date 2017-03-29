using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapsSortAlmostSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = Sort(new List<int>() { 3,-1,2,6,4,5,8 }, 2);
        }

        public static List<int> Sort(List<int> a, int k)
        {
            var sDict = new SortedDictionary<int, short>();
            var resp = new List<int>();
            for (int i = 0; i <= k; ++i)
            {
                sDict.Add(a[i], 0);
            }

            for (int i = k + 1; i < a.Count; ++i)
            {
                resp.Add(sDict.ElementAt(0).Key);
                sDict.Remove(sDict.ElementAt(0).Key);
                sDict.Add(a[i],0);
            }

            while (sDict.Count > 0)
            {
                resp.Add(sDict.ElementAt(0).Key);
                sDict.Remove(sDict.ElementAt(0).Key);
            }
            return resp;
        }
    }
}
