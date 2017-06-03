using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingMagicIndexWithNonDistintic
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindMagicIndex(new List<int> { -2, 1, 1, 1, 1, 2, 3 });
            r = FindMagicIndex(new List<int> { -2, -1, 0, 4, 4, 4, 8, 9 });
        }

        public static int FindMagicIndex(List<int> a)
        {
            return FindMagicIndex(a, 0, a.Count - 1);
        }
        public static int FindMagicIndex(List<int> a, int l, int r)
        {
            if (r < l) return -1;
            var midIndex = l + (r - l) / 2;
            var midVal = a[midIndex];
            if (midIndex == midVal) return midIndex;

            var leftIndex = Math.Min(midIndex - 1, midVal);
            var leftVal = FindMagicIndex(a, l, leftIndex);
            if (leftVal != -1) return leftVal;

            var rightIndex = Math.Max(midIndex + 1, midVal);
            var rightVal = FindMagicIndex(a, rightIndex, r);
            return rightVal;
        }
    }
}
