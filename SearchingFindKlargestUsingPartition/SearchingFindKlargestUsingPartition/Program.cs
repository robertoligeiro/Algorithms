using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingFindKlargestUsingPartition
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 3, 2, 1, 5, 4 };
            var r = FindK(l, 3); //3rd largest is 3
            r = FindK(l, 1); //1st largest is 5
            r = FindK(l, 2); //3rd largest is 4
            r = FindK(l, 5); //5rd largest is 1
        }

        public static int FindK(List<int> a, int k)
        {
            var left = 0;
            var right = a.Count - 1;
            while (left <= right)
            {
                int pivot = Partition(a, left, right);
                if (pivot == k - 1) return a[pivot];
                if (pivot > k - 1)
                    right = pivot - 1;
                else
                    left = pivot + 1;
            }

            return -1;
        }

        public static int Partition(List<int> a, int left, int right)
        {
            var pivot = new Random().Next(left, right);
            Swap(left, pivot, a);

            var i = left + 1;
            var j = right;
            while (i <= j)
            {
                while (i <= right && a[i] > a[left])
                {
                    ++i;
                }

                while (j >= left && a[j] < a[left])
                {
                    --j;
                }

                if (j < i) break;
                Swap(i, j, a);
            }

            Swap(left, j, a);
            return j;
        }

        public static void Swap(int i, int j, List<int> a)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
