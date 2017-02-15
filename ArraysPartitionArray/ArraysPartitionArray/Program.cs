using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysPartitionArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Random();
            var a = new List<int>();
            for (int i = 0; i < 20; ++i)
            {
                a.Add(r.Next(0,10));
            }

            PartitionArray(a, 5);
        }

        public static void PartitionArray(List<int> a, int p)
        {
            int pivot = a[p];
            int i = 1;
            int j = a.Count - 1;
            Swap(0, p, a);
            while (true)
            {
                while (i <= a.Count - 1 && a[i] <= pivot)
                {
                    i++;
                }

                while (j >= 0 && a[j] > pivot)
                {
                    j--;
                }

                if (j < i) break;
                Swap(i, j, a);
            }

            Swap(0, j, a);
        }

        public static void Swap(int i, int j, List<int> a)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
