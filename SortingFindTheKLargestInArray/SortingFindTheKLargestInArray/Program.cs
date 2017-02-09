using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingFindTheKLargestInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new List<int>() { 3, 2, 1, 5, 4 };
            var a = new List<int>();
            Random rd = new Random();
            for (int i = 0; i < 10; ++i)
            {
                a.Add(rd.Next(0,10000));
            }
            var r = FindK(a, 2);
        }

        public static int FindK(List<int> a, int k)
        {
            return FindK(a, a.Count - k + 1, 0, a.Count - 1);
        }
        public static int FindK(List<int> a, int k, int left, int right)
        {
            int p = Partition(a, left, right);
            if (p == k - 1)
            {
                return a[p];
            }
            if (p > k - 1)
            {
                return FindK(a, k, left, p - 1);
            }

            return FindK(a, k, p + 1, right);
        }
        public static int Partition(List<int> a, int left, int right)
        {
            int p = a[left];
            int i = left + 1;
            int j = right;

            while (true)
            {
                while (i <= right && a[i] < p)
                {
                    i++;
                }

                while (j >= left + 1 && a[j] > p)
                {
                    j--;
                }

                if (i >= j) break;

                int t = a[i];
                a[i] = a[j];
                a[j] = t;
            }

            a[left] = a[j];
            a[j] = p;

            return j;
        }

    }
}
