using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingFindValueEqualsIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = FindIndex(new List<int>() { -2,-1,0,1,2,3,6,9,10,11,12,13});
        }
        public static int FindIndex(List<int> a)
        {
            var left = 0;
            var right = a.Count - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (mid == a[mid]) return mid;
                if (a[mid] < mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return -1;
        }
    }
}
