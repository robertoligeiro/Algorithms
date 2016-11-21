using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a  = { 5, 4, 8, 3, 0, 7, 6 };
            //QuickSortSolution.quickSort(a, 0, a.Length - 1);

            int i = QuickSortSolution.findKSmallest(a, 0, a.Length - 1, 6);
        }

        public class QuickSortSolution
        {
            public static int findKSmallest(int[] a, int start, int end, int k)
            {

                if (start == end) return end;

                int midle = partition(a, start, end);

                if (midle - start >= k)
                {
                    return findKSmallest(a, start, midle, k);
                }
                else
                {
                    return findKSmallest(a, midle + 1, end, k - (midle - start));
                }
            }

            public static void quickSort(int[]a, int start, int end)
            {
                if (start < end)
                {
                    int midle = partition(a, start, end);

                    quickSort(a, start, midle - 1);
                    quickSort(a, midle + 1, end);
                }

            }

            private static int partition(int[] numbers, int left, int right)
            {
                int pivot = numbers[left];
                while (true)
                {
                    while (numbers[left] < pivot)
                        left++;

                    while (numbers[right] > pivot)
                        right--;

                    if (left < right)
                    {
                        int temp = numbers[right];
                        numbers[right] = numbers[left];
                        numbers[left] = temp;
                    }
                    else
                    {
                        return right;
                    }
                }
            }
        }
    }
}
