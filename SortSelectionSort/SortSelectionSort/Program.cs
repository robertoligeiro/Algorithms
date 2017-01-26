using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortSelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[10];
            Random r = new Random();
            for (int i = 0; i < a.Length; ++i)
            {
                a[i] = r.Next(0, 100);
            }

            SelectionSort(a);
        }

        public static void SelectionSort(int[] a)
        {
            var l = a.Length;
            for (int i = 0; i < l; ++i)
            {
                var min = i;
                int comp = a[i];

                for (int j = i + 1; j < l; ++j)
                {
                    if (a[j] < comp)
                    {
                        min = j;
                        comp = a[j];
                    }
                }

                var temp = a[i];
                a[i] = a[min];
                a[min] = temp;
            }
        }
    }
}
