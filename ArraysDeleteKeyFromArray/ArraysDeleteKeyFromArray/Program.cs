using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysDeleteKeyFromArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var l = new List<int> { 1, 2, 3, 4, 4, 5, 6, 7, 3, 8, 8, 3, 3, 3, 9, 3,3};
            var r = DeleteKey(l, 3);
        }

        public static int DeleteKey(List<int> a, int key)
        {
            int nextWrite = 0;
            for (int i = 0; i < a.Count; ++i)
            {
                if (a[i] != key) a[nextWrite++] = a[i];
            }

            a.RemoveRange(nextWrite, a.Count - nextWrite);
            return nextWrite;
        }
    }
}
