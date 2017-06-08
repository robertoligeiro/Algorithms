using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePeakAlleyElementAlt
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int>() { 5, 3, 1, 2, 3 };
           SortToPeakAndAlley(a);
        }

        public static void SortToPeakAndAlley(List<int> a)
        {
            for (int i = 1; i < a.Count - 1; i += 2)
            {
                var biggestIndex = BiggestIndex(a, i - 1, i + 1);
                if (biggestIndex != i)
                {
                    var t = a[i];
                    a[i] = a[biggestIndex];
                    a[biggestIndex] = t;
                }
            }
        }

        public static int BiggestIndex(List<int> a, int l, int r)
        {
            int biggest = 0;
            if (a[l] > a[l + 1]) biggest = l;
            else biggest = l + 1;
            if (a[biggest] < a[r]) biggest = r;
            return biggest;
        }
    }
}
