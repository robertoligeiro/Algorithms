using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingComputeIntersectionSortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = ComputeIntersect(new List<int>() { 2, 3, 3, 5, 5, 6, 7, 7, 8, 12 }, new List<int>() { 5, 5, 6, 8, 8, 9, 10, 10 });
        }

        public static List<int> ComputeIntersect(List<int> a, List<int> b)
        {
            var i = 0;
            var j = 0;
            var resp = new List<int>();
            var rr = resp.LastOrDefault();
            while (i < a.Count && j < b.Count)
            {
                if (a[i] == b[j])
                {
                    if (resp.Count == 0 || resp.LastOrDefault() != a[i]) resp.Add(a[i]);
                    i++; j++;
                }
                else
                {
                    if (a[i] < b[j]) i++;
                    else j++;
                }
            }
            return resp;
        }
    }
}
