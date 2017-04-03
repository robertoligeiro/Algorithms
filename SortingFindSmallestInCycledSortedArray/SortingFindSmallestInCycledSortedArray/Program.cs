using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingFindSmallestInCycledSortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static int FindSmallest(List<int> a)
        {
            var left = 0;
            var right = a.Count - 1;
            while (left < right)
            {
                var mid = left + (right - left) / 2;
                if (a[mid] > a[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }
    }
}
