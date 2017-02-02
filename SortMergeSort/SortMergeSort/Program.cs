using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortMergeSort
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

            MergeSort(l);
        }

        public static void MergeSort(List<int> a)
        {
            var aux = new List<int>(a);
            MergeSort(a, aux, 0, a.Count -1);
        }
        public static void MergeSort(List<int> a, List<int> aux, int left, int right)
        {
            if (right <= left) return;

            var mid = left + (right - left) / 2;
            MergeSort(a, aux, left, mid);
            MergeSort(a, aux, mid + 1, right);
            Merge(a, aux, left, right, mid);
        }
        public static void Merge(List<int> a, List<int>aux, int left, int right, int mid)
        {
            for (var i = 0; i < a.Count; ++i)
            {
                aux[i] = a[i];
            }
            int lo = left;
            int hi = mid+1;
            for (var i = left; i <= right; ++i)
            {
                if (lo > mid) a[i] = aux[hi++];
                else if (hi > right) a[i] = aux[lo++];
                else if (aux[lo] < aux[hi]) a[i] = aux[lo++];
                else a[i] = aux[hi++];
            }
        }
    }
}
