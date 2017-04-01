using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingFindTheFirstElementGraterThanK
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401 };

            var r = FindFirstGreater(l, 108); // 5
            r = FindFirstGreater(l, 285); // 9
            r = FindFirstGreater(l, -14); // 1
            r = FindFirstGreater(l, 401); // -1
            r = FindFirstGreater(l, 243); // 6
            r = FindFirstGreater(l, 32); // -1
        }

        public static int FindFirstGreater(List<int> a, int k)
        {
            var left = 0;
            var right = a.Count - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (a[mid] == k)
                {
                    if (mid + 1 < a.Count && a[mid + 1] != k)
                    {
                        return mid + 1;
                    }

                    left = mid + 1;
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
            return -1;
        }
    }
}
