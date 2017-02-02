using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortInsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>();
            var rand = new Random();
            for (int i = 0; i < 10; ++i)
            {
                l.Add(rand.Next(0, 100));
            }

            InsertionSort(l);
        }

        public static void InsertionSort(List<int> a)
        {
            for (int i = 0; i < a.Count; ++i)
            {
                int inv = i;
                for (int j = inv-1; j >= 0; --j)
                {
                    if (a[inv] < a[j])
                    {
                        var t = a[inv];
                        a[inv] = a[j];
                        a[j] = t;
                        inv = j;
                    }
                    else break;
                }
            }
        }
    }
}
