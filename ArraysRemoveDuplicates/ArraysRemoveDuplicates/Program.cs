using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysRemoveDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int>() { 1, 2, 2, 2, 3, 3, 3, 4 };
            var r = RemoveDups(l);
            var l1 = new List<int>() { 1, 2, 2, 2, 3, 3, 3, 4, 4 };
            var r1 = RemoveDups(l1);
            var l2 = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1 };
            var r2 = RemoveDups(l2);
        }

        public static int RemoveDups(List<int> a)
        {
            int nextWrite = 1;
            for (int i = 0; i < a.Count;)
            {
                int j = i + 1;
                while (j < a.Count && a[i] == a[j])
                { j++; }
                if (j >= a.Count) break;

                a[nextWrite++] = a[j];
                i = j;
            }

            a.RemoveRange(nextWrite, a.Count - nextWrite);
            return nextWrite;
        }
    }
}
