using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 5, 2, 6, 4, 7, 10, 1, 9, 3, 8 };

            array = MergeSortSolution.MergeSort(array);

            // Print the sorted list
            for (int index = 0; index < array.Length; index++)
            {
                Console.WriteLine("element[{0}] = {1}", index, array[index]);
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        public class MergeSortSolution
        {
            public static int[] MergeSort(int[] a)
            {
                if (a.Length <= 1) return a;
                int mid = a.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[a.Length - mid];
                Array.Copy(a, left, mid);
                Array.Copy(a, mid, right, 0, right.Length);
                left = MergeSort(left);
                right = MergeSort(right);

                return Merge(left, right);
            }

            private static int[] Merge(int[] left, int[] right)
            {
                List<int> r = right.ToList<int>();
                List<int> l = left.ToList<int>();
                List<int> result = new List<int>();

                while (l.Count > 0 || r.Count > 0)
                {
                    if (l.Count > 0 && r.Count > 0)
                    {
                        if (l[0] < r[0])
                        {
                            result.Add(l[0]);
                            l.RemoveAt(0);
                        }
                        else
                        {
                            result.Add(r[0]);
                            r.RemoveAt(0);
                        }
                    }
                    else
                    {
                        result.AddRange(l);
                        result.AddRange(r);
                        break;
                    }
                }

                return result.ToArray();
            }
        }
    }
}
