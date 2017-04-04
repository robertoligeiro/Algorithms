using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindKlargestWithHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 3, 2, 1, 5, 4 };
            var r = FindK(l, 3); // 3rd is 3, index is 0 (0 is returned)
            r = FindK(l, 1); // 1st is 5, index is 3 (3 returned)
            r = FindK(l, 4); // 4th is 2, index is 1 (1 returned)
        }

        //return index of the item
        public static int FindK(List<int> a, int k)
        {
            var sDict = new SortedDictionary<int, int>();
            for (int i = 0; i < a.Count; ++i)
            {
                if (sDict.Count < k)
                {
                    sDict.Add(a[i], i);
                }
                else
                {
                    if (sDict.First().Key < a[i])
                    {
                        sDict.Remove(sDict.First().Key);
                        sDict.Add(a[i], i);
                    }
                }
            }

            return sDict.First().Value;
        }
    }
}
