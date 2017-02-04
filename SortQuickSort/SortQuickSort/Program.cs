using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortQuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>();
            var rand = new Random();
            for (int i = 0; i < 10; ++i)
            {
                l.Add(rand.Next(0,100));
            }

            QuickSort(l);
        }

        public static void QuickSort(List<int> a)
        {
            QuickSort(a, 0, a.Count - 1);
        }
        public static void QuickSort(List<int> a, int left, int right)
        {
            if (right <= left) return;
            int partition = Partition(a, left, right);
            QuickSort(a, left, partition - 1);
            QuickSort(a, partition + 1, right);
        }

        public static int Partition(List<int> a, int left, int right)
        {
            int lo = left;
            int hi = right+1;
            int k = a[left];
            while (true)
            {
                while (k > a[++lo])
                {
                    if (lo == right) break; 
                }

                while (k < a[--hi])
                {
                    if (hi == left) break;
                }

                if (hi <= lo) break;

                var t = a[lo];
                a[lo] = a[hi];
                a[hi] = t;
            }

            a[left] = a[hi];
            a[hi] = k;
            return hi;
        }
    }
}
