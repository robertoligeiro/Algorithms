using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingFindTheFirstOccurenceOfKinSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401};

            var r = FindFirstK(l, 108); // 3
            r = FindFirstK(l, 285); // 6
            r = FindFirstK(l, -14); // 0
            r = FindFirstK(l, 401); // 9
            r = FindFirstK(l, 243); // 5
            r = FindFirstK(l,32); // -1
        }

        public static int FindFirstK(List<int> a, int k)
        {
            var index = -1;
            var left = 0;
            var right = a.Count - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (a[mid] == k)
                {
                    index = mid;
                    if (mid - 1 > 0 && a[mid - 1] == k)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        return index;
                    }
                }
                else
                {
                    if (a[mid] < k)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
            return index;
        }
    }
}
