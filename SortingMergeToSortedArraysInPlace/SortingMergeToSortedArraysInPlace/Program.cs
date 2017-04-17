using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMergeToSortedArraysInPlace
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[7] { 5, 13, 17 , 0, 0, 0, 0};
            int[] b = new int[4] { 3, 7, 11, 19 };
            Merge(a, 3, b, 4);
        }

        public static void Merge(int[] a, int sizeA, int[] b, int sizeB)
        {
            var nextWrite = sizeA + sizeB - 1;
            sizeA--;sizeB--;
            while (sizeA >= 0 && sizeB >= 0)
            {
                if (a[sizeA] > b[sizeB]) a[nextWrite] = a[sizeA--];
                else a[nextWrite] = b[sizeB--];
                nextWrite--;
            }
            while (sizeB >= 0)
                a[nextWrite--] = b[sizeB--];
        }
    }
}
