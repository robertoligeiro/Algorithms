using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursionCountInversions
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 4, 3, 5, 1 };
            var r = CountInversions(a);
        }

        public static int CountInversions(int[] a)
        {
            int inversions = 0;
            var r = MergeSortAndGetInversion(a, out inversions);
            return inversions;
        }

        public static int[] MergeSortAndGetInversion(int[] a, out int inversions)
        {
            if (a.Length <= 1)
            {
                inversions = 0;
                return a;
            }

            int mid = a.Length / 2;

            var left = new int[mid];
            var right = new int[a.Length - mid];
            Array.Copy(a, left, mid);
            Array.Copy(a, mid, right, 0, right.Length);

            int invL = 0;
            int invR = 0;
            left = MergeSortAndGetInversion(left, out invL);
            right = MergeSortAndGetInversion(right, out invR);

            int invM = 0;
            a = Merge(left, right, out invM);

            inversions = invL + invR + invM;
            return a;
        }

        public static int[] Merge(int[] a, int[] b, out int countInv)
        {
            var r = new int[a.Length + b.Length];
            int i = 0;
            int j = 0;
            int index = 0;
            countInv = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    r[index] = a[i++];
                }
                else
                {
                    countInv++;
                    r[index] = b[j++];
                }
                index++;
            }

            if (i < a.Length)
            {
                for (int c = i; c < a.Length; c++)
                {
                    r[index] = a[c];
                }
            }

            if (j < b.Length)
            {
                for (int c = j; c < b.Length; c++)
                {
                    countInv++;
                    r[index] = b[c];
                }
            }
            return r;
        }
    }
}
